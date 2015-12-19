// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using Starcounter.Powershell.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Starcounter.Powershell
{
    static class AdministratorClient
    {
        // TODO(mtornwall): Allow this to be configured on a per-session basis.
        // This would allow administration of remote servers.
        private static readonly string BaseUrl = "http://localhost:8181";

        private static HttpClient _client = new HttpClient();

        public static DatabaseJson GetDatabase(string id)
        {
            return Get<DatabaseJson>(BaseUrl, "/api/admin/databases", id);
        }

        public static IList<DatabaseJson> GetDatabases()
        {
            return Get<CollectionJson<DatabaseJson>>(BaseUrl, "/api/admin/databases").Items;
        }

        public static void StartDatabase(string id, bool awaitCompletion)
        {
            RunTask(
                new StartDatabaseTaskJson()
                {
                    DatabaseName = id
                },
                awaitCompletion,
                BaseUrl, "/api/tasks/startdatabase");
        }

        public static void StopDatabase(string id, bool awaitCompletion)
        {
            RunTask(
                new StopDatabaseTaskJson()
                {
                    DatabaseName = id
                },
                awaitCompletion,
                BaseUrl, "/api/tasks/stopdatabase");
        }

        public static void CreateDatabase(DatabaseSettingsJson settings, bool awaitCompletion)
        {
            RunTask(
                new CreateDatabaseTaskJson()
                {
                    Settings = settings
                },
                awaitCompletion,
                BaseUrl, "/api/tasks/createdatabase");
        }

        public static void DeleteDatabase(string id, bool awaitCompletion)
        {
            RunTask(
                new DeleteDatabaseTaskJson()
                {
                    DatabaseName = id
                },
                awaitCompletion,
                BaseUrl, "/api/tasks/deletedatabase");
        }

        public static DatabaseSettingsJson GetDefaultDatabaseSettings()
        {
            return Get<DatabaseSettingsJson>(BaseUrl, "/api/admin/settings/database");
        }

        public static DatabaseSettingsJson GetDatabaseSettings(string id)
        {
            return Get<DatabaseSettingsJson>(BaseUrl, "/api/admin/databases/", id, "/settings");
        }

        public static void SetDatabaseSettings(string id, DatabaseSettingsJson json)
        {
            Put(json, BaseUrl, "/api/admin/databases", id, "/settings");
        }

        public static LogJson GetLog(
            bool filterDebug, bool filterNotice,
            bool filterWarning, bool filterError,
            List<string> filterSource, int maxItems)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("?debug={0}", filterDebug ? "true" : "false");
            sb.AppendFormat("&notice={0}", filterNotice ? "true" : "false");
            sb.AppendFormat("&warning={0}", filterWarning ? "true" : "false");
            sb.AppendFormat("&error={0}", filterError ? "true" : "false");
            sb.AppendFormat("&source={0}", string.Join(";", filterSource));
            sb.AppendFormat("&maxitems={0}", maxItems);
            return Get<LogJson>(BaseUrl, "/api/admin/log" + sb.ToString());
        }

        #region Raw request methods

        private static void RunTask<TRequest>(TRequest json, bool awaitCompletion, string baseUri, params object[] parts)
        {
            var task = Post<TRequest, TaskJson>(json, baseUri, parts);

            if (awaitCompletion)
            {
                while (true)
                {
                    switch (task.Status)
                    {
                        case 0:
                            // Task has completed.
                            return;

                        case 1:
                            // Task is still running. Keep waiting.
                            // NOTE: We're blocking the Powershell thread anyway, so we might as well suspend the thread.
                            // TODO(mtornwall): Use some kind of exponential backoff?
                            System.Threading.Thread.Sleep(1000);
                            task = Get<TaskJson>(BaseUrl, task.TaskUri);
                            break;

                        case -1:
                            // Task failed.
                            // TODO(mtornwall): Custom exception class.
                            throw new System.Exception("Task failed: " + task.Message);

                        default:
                            // TODO(mtornwall): Custom exception class.
                            throw new System.Exception("Invalid task status code.");
                    }
                }
            }
        }

        private static TResponse Get<TResponse>(string baseUri, params object[] parts)
        {
            return Task.Run(async () =>
            {
                using (var stream = await _client.GetStreamAsync(BuildUri(baseUri, parts)))
                {
                    return DeserializeJson<TResponse>(stream);
                }
            }).Result;
        }

        private static void Post<TRequest>(TRequest json, string baseUri, params object[] parts)
        {
            Task.Run(async () =>
            {
                using (var stream = SerializeJson(json))
                using (var response =
                    await _client.PostAsync(BuildUri(baseUri, parts), new StreamContent(stream)))
                {
                    response.EnsureSuccessStatusCode();
                }
            }).Wait();
        }

        private static TResponse Post<TRequest, TResponse>(TRequest json, string baseUri, params object[] parts)
        {
            return Task.Run(async () =>
            {
                using (var reqStream = SerializeJson(json))
                using (var response =
                    await _client.PostAsync(BuildUri(baseUri, parts), new StreamContent(reqStream)))
                using (var respStream = await response.Content.ReadAsStreamAsync())
                {
                    response.EnsureSuccessStatusCode();
                    return DeserializeJson<TResponse>(respStream);
                }
            }).Result;
        }

        private static void Put<TRequest>(TRequest json, string baseUri, params object[] parts)
        {
            Task.Run(async () =>
            {
                using (var stream = SerializeJson(json))
                using (var response =
                    await _client.PutAsync(BuildUri(baseUri, parts), new StreamContent(stream)))
                {
                    response.EnsureSuccessStatusCode();
                }
            }).Wait();
        }

        #endregion

        #region Misc support methods

        private static string BuildUri(string baseUri, params object[] parts)
        {
            var sb = new StringBuilder();
            sb.Append(baseUri.TrimEnd('/'));
            sb.Append('/');
            sb.Append(string.Join("/", parts.Select(p => p.ToString()).Select(s => s.Trim('/'))));
            return sb.ToString();
        }

        private static Stream SerializeJson<T>(T json)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var ms = new MemoryStream();
            serializer.WriteObject(ms, json);
            ms.Position = 0;
            return ms;
        }

        private static T DeserializeJson<T>(Stream stream)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }

        #endregion
    }
}

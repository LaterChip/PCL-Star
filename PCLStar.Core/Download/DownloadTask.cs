using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PCLStar.Core.Download
{
    public class DownloadTask
    {
        public string Url { get; set; }
        public string SavePath { get; set; }
        public long? ExpectedSize { get; set; }
        public string ExpectedSha1 { get; set; }

        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<(bool Success, Exception Error)> ExecuteAsync(IProgress<float> progress = null, CancellationToken token = default)
        {
            try
            {
                var response = await HttpClient.GetAsync(Url, HttpCompletionOption.ResponseHeadersRead, token);
                response.EnsureSuccessStatusCode();
                var total = response.Content.Headers.ContentLength ?? -1L;
                var buffer = new byte[8192];
                await using var stream = await response.Content.ReadAsStreamAsync(token);
                await using var file = File.Create(SavePath);
                long downloaded = 0;
                int len;
                while ((len = await stream.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
                {
                    await file.WriteAsync(buffer, 0, len, token);
                    downloaded += len;
                    progress?.Report((float)downloaded / total);
                }
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex);
            }
        }
    }
}

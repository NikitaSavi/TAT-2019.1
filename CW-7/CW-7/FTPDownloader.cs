using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CW_7
{
    /// <summary>
    /// Handles download from a provided FTP server.
    /// </summary>
    public class FtpDownloader
    {
        /// <summary>
        /// Path to the directory.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// List with file names in the <see cref="Path"/> directory.
        /// </summary>
        public List<string> FilesNames { get; private set; }

        /// <summary>
        /// The download time of parallel method.
        /// </summary>
        public TimeSpan ParallelDownloadTime { get; private set; }

        /// <summary>
        /// The download time of nonparallel method.
        /// </summary>
        public TimeSpan NonParallelDownloadTime { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FtpDownloader"/> class.
        /// </summary>
        /// <param name="path">
        /// Path to the directory.
        /// </param>
        public FtpDownloader(string path)
        {
            this.Path = path;
        }

        /// <summary>
        /// The method writes names of files to list of string.
        /// </summary>
        public void GetFiles()
        {
            this.FilesNames = new List<string>();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(this.Path);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                this.FilesNames.Add(line);
            }

            response.Close();
            reader.Close();
            responseStream.Close();

            Console.WriteLine("Following files were found on server:");
            foreach (var file in this.FilesNames)
            {
                Console.WriteLine(file);
            }
        }

        /// <summary>
        /// Downloads a file.
        /// </summary>
        /// <param name="file">
        /// The file to download.
        /// </param>
        public void DownloadFile(object file)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(this.Path + file);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            FileStream fileStream = new FileStream((string)file, FileMode.Create);
            byte[] buffer = new byte[64];
            int size;
            while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fileStream.Write(buffer, 0, size);
            }

            response.Close();
            responseStream.Close();
            fileStream.Close();
            Console.WriteLine($"{file} is downloaded.");
        }

        /// <summary>
        /// Initializes a parallel download.
        /// </summary>
        public void ParallelDownload()
        {
            Console.WriteLine("\nStarting parallel download.");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Task[] tasks = new Task[this.FilesNames.Count];
            for (int i = 0; i < this.FilesNames.Count; i++)
            {
                tasks[i] = new Task(this.DownloadFile, this.FilesNames[i]);
            }

            foreach (var task in tasks)
            {
                task.Start();
            }

            Task.WaitAll(tasks);
            stopwatch.Stop();
            this.ParallelDownloadTime = stopwatch.Elapsed;
            Console.WriteLine("Parallel download is finished.");
        }

        /// <summary>
        /// Initializes a nonparallel download.
        /// </summary>
        public void NonParallelDownload()
        {
            Console.WriteLine("\nStarting nonparallel download.");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var file in this.FilesNames)
            {
                this.DownloadFile(file);
            }

            stopwatch.Stop();
            this.NonParallelDownloadTime = stopwatch.Elapsed;
            Console.WriteLine("Nonparallel download is finished.");
        }

        /// <summary>
        /// Compares times of of parallel and nonparallel methods.
        /// </summary>
        public void CompareMethods()
        {
            Console.WriteLine(
                $"\nNonparallel time: {this.NonParallelDownloadTime}\nParallel time: {this.ParallelDownloadTime}\n");
            Console.WriteLine(
                this.NonParallelDownloadTime < this.ParallelDownloadTime
                    ? "Nonparallel method is faster"
                    : "Parallel method is faster");
        }
    }
}
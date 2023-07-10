﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace GlobalAI.Utils.DataUtils
{
    public static class FileUtils
    {
        private static Dictionary<string, string> GetParams(string uri)
        {
            var matches = Regex.Matches(uri, @"[\?&](([^&=]+)=([^&=#]*))", RegexOptions.Compiled);
            var dic = matches.Cast<Match>().ToDictionary(
                m => Uri.UnescapeDataString(m.Groups[2].Value),
                m => Uri.UnescapeDataString(m.Groups[3].Value)
            );
            foreach (var d in dic)
            {
                dic[d.Key] = HttpUtility.UrlDecode(d.Value);
            }
            return dic;
        }

        /// <summary>
        /// CONVERT PATH LUU TRONG DB THANH PATH VAT LY
        /// </summary>
        /// <param name="pathDb"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="FaultException"></exception>
        public static GetFullPathResultDto GetFullPathFile(string pathDb, string filePath)
        {
            var path = GetParams(pathDb);
            var folder = path["folder"];
            var fileName = path["file"];

            var fullPath = Path.Combine(filePath, folder, fileName);
            return new GetFullPathResultDto
            {
                FileName = fileName,
                Folder = folder,
                FullPath = fullPath
            };
        }

        /// <summary>
        /// CONVERT PATH LUU TRONG DB THANH PATH VAT LY
        /// </summary>
        /// <param name="pathDb"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="FaultException"></exception>
        public static GetFullPathResultDto GetFullPathFileNoCheckExists(string pathDb, string filePath)
        {
            var path = GetParams(pathDb);
            var folder = path["folder"];
            var fileName = path["file"];

            var fullPath = Path.Combine(filePath, folder, fileName);

            return new GetFullPathResultDto
            {
                FileName = fileName,
                Folder = folder,
                FullPath = fullPath
            };
        }

        public static void RemoveOrderContractFile(OrderContractFileRemoveDto orderContractFile, string filePath){
            if (orderContractFile.FileTempUrl != null)
            {
                var fileResult = GetFullPathFileNoCheckExists(orderContractFile.FileTempUrl, filePath);
                if (File.Exists(fileResult.FullPath))
                {
                    File.Delete(fileResult.FullPath);
                }
            }
            
            if (orderContractFile.FileTempPdfUrl != null)
            {
                var fileResult = GetFullPathFileNoCheckExists(orderContractFile.FileTempPdfUrl, filePath);
                if (File.Exists(fileResult.FullPath))
                {
                    File.Delete(fileResult.FullPath);
                }
            }
             
            if (orderContractFile.FileScanUrl != null)
            {
                var fileResult = GetFullPathFileNoCheckExists(orderContractFile.FileScanUrl, filePath);
                if (File.Exists(fileResult.FullPath))
                {
                    File.Delete(fileResult.FullPath);
                }
            }

            if (orderContractFile.FileSignatureUrl != null)
            {
                var fileResult = GetFullPathFileNoCheckExists(orderContractFile.FileSignatureUrl, filePath);
                if (File.Exists(fileResult.FullPath))
                {
                    File.Delete(fileResult.FullPath);
                }

                //xóa file pdf có con dấu
                var FullSignPath = fileResult.FullPath.Replace(".pdf", "-Sign.pdf");
                if (File.Exists(FullSignPath))
                {
                    File.Delete(FullSignPath);
                }
            }
        }
}

    public class GetFullPathResultDto
    {
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public string Folder { get; set; }
    }

    public class OrderContractFileRemoveDto
    {
        public string FileTempUrl { get; set; }
        public string FileTempPdfUrl { get; set; }
        public string FileSignatureUrl { get; set; }
        public string FileScanUrl { get; set; }
    }

}

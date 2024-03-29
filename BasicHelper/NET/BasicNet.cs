﻿using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace BasicHelper.Net
{
    public class BasicNet
    {
        /// <summary>
        /// 检验是否拥有网络连接
        /// </summary>
        /// <param name="target">测试的目标</param>
        /// <param name="waitTime">等待时间</param>
        /// <returns>是否拥有网络连接</returns>
        public static bool IsWebConected(string target, int waitTime)
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions
                {
                    DontFragment = true
                };
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                PingReply objPinReply = objPingSender.Send(target, waitTime, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 返回网络连接失败的原因
        /// </summary>
        /// <param name="target">测试目标</param>
        /// <param name="waitTime">等待时间</param>
        /// <returns>返回失败原因</returns>
        public static Exception WebConectionError(string target, int waitTime)
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions
                {
                    DontFragment = true
                };
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                PingReply objPinReply = objPingSender.Send(target, waitTime, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                return null;
            }
            catch (Exception result)
            {
                return result;
            }
        }

        /// <summary>
        /// 从服务器下载文件
        /// </summary>
        /// <param name="serverFilePath">服务器上的文件位置</param>
        /// <param name="targetPath">存储到本地的文件位置</param>
        public static void DownloadFile(string serverFilePath, string targetPath)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverFilePath);
            WebResponse respone = request.GetResponse();
            Stream netStream = respone.GetResponseStream();
            Stream fileStream = new FileStream(targetPath, FileMode.Create);
            byte[] read = new byte[1024];
            int realReadLen = netStream.Read(read, 0, read.Length);
            while (realReadLen > 0)
            {
                fileStream.Write(read, 0, realReadLen);
                realReadLen = netStream.Read(read, 0, read.Length);
            }
            netStream.Close();
            fileStream.Close();
        }

        /// <summary>
        /// 从服务器下载文件
        /// </summary>
        /// <param name="serverFilePath">服务器上的文件位置</param>
        /// <param name="targetPath">存储到本地的文件位置</param>
        public static void WebDownloadFile(string serverFilePath, string targetPath)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(serverFilePath, targetPath);
            webClient.Dispose();
        }
    }
}

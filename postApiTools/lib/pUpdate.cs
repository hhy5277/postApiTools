﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.lib
{
    /// <summary>
    /// 更新服务
    /// </summary>
    public class pUpdate
    {
        /// <summary>
        /// 程序集版本获取
        /// </summary>
        public string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>
        /// download
        /// </summary>
        public const string versionuDownload = "http://wstatic.apizl.com/postapitools/setup.exe";
        /// <summary>
        /// 请求URL
        /// </summary>
        public const string versionuUrl = "http://wstatic.apizl.com/postapitools/version.txt";

        /// <summary>
        /// version_desc URL
        /// </summary>
        public const string versionuDescUrl = "http://wstatic.apizl.com/postapitools/version_desc.txt";

        /// <summary>
        /// 更新说明
        /// </summary>
        public string updateDesc = phttp.HttpGetCustom(versionuDescUrl, "");
        /// <summary>
        /// 服务器版本
        /// </summary>
        public string serverVersion = phttp.HttpGetCustom(versionuUrl, "");

        /// <summary>
        /// 文件目录
        /// </summary>
        public string setup = Config.exePath + "/setup.exe";

        /// <summary>
        /// 判断是否需要更新
        /// </summary>
        /// <returns></returns>
        public bool isUpdate()
        {
            Version now = new Version(version);
            Version server = new Version(serverVersion);
            if (server > now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <returns></returns>
        public bool download()
        {
            return phttp.HttpDownload(versionuDownload, setup);
        }

        /// <summary>
        /// 获取版本说明
        /// </summary>
        /// <returns></returns>
        public string getVersionDesc()
        {
            return phttp.HttpGetCustom(versionuDescUrl, "");
        }
    }
}

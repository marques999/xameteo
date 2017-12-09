﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    public class Places
    {
        /// <summary>
        /// </summary>
        public List<ApixuAdapter> List { get; } = new List<ApixuAdapter>();

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Task<ApixuForecast> Forecast(int index)
        {
            return index < List.Count ? Xameteo.Api.Forecast(List[index], 15) : null;
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public bool Insert(ApixuAdapter adapter)
        {
            if (List.FirstOrDefault(it => it.Parameters == adapter.Parameters) != null)
            {
                return false;
            }

            List.Add(adapter);
            Xameteo.Settings.Places = JsonConvert.SerializeObject(List, Formatting.None);

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public bool Remove(ApixuAdapter adapter)
        {
            if (List.Remove(adapter))
            {
                Xameteo.Settings.Places = JsonConvert.SerializeObject(List, Formatting.None);
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Task<ApixuCurrent>> Current()
        {
            return List.Select(it => Xameteo.Api.Current(it));
        }

        /// <summary>
        /// </summary>
        /// <param name="jsonData"></param>
        public Places(string jsonData)
        {
            try
            {
                List.AddRange(JsonConvert.DeserializeObject<IEnumerable<ApixuAdapter>>(jsonData));
            }
            catch (Exception exception)
            {
                Xameteo.Dialogs.Alert(exception);
            }
        }
    }
}
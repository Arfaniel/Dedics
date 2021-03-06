﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;


namespace Dedics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> list = new List<User>();
            WebClient wb = new WebClient();
            wb.Encoding = Encoding.UTF8;
            string allsite = wb.DownloadString(@"http://usb-proshivka.forumgrad.com/t131-topic");
            string pattern = @"[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\@?\;?[\w0-9]+\;[\w0-9]+\/?\s?[\w0-9]\/?|[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}|[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\@?\;?[\w0-9]+\;[\w0-9]+\/?\s?[\w0-9]\/?\s?[/]{1}[\w][/]{1}";
            Regex reg = new Regex(pattern);
            var q1 = reg.Matches(allsite);
            foreach (var item in q1)
            {
                User temp = new User();
                string temp1 = item.ToString();
                //Console.WriteLine(temp1);
                Regex ipPattern = new Regex(@"[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}");
                temp.ip = ipPattern.Match(temp1).Value;
                temp1 = temp1.Replace(';', '@');
                if (temp1.Contains("@"))
                {
                    string[] userData = temp1.Split('@');
                    if (userData.Length == 1)
                    {
                        temp.login = userData[0];
                        temp.pass = null;
                    }
                    if (userData.Length == 2)
                    {
                        temp.login = userData[1];
                        temp.pass = null;
                    }
                    if (userData.Length == 3)
                    {
                        temp.login = userData[1];
                        temp.pass = userData[2];
                    }
                }
                else
                {
                    temp.login = null;
                    temp.pass = null;
                }
                list.Add(temp);
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
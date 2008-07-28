/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2008 Vlad Setchin <envman-dev@googlegroups.com>

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using IWshRuntimeLibrary;


namespace EnvManager
{
    public class EnvVarManager
    {
        WshShell shell = new WshShell();
        private const string USER_REGISTRY_KEY = @"HKEY_CURRENT_USER\Environment\";
        private const string SYSTEM_REGISTRY_KEY = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment\";

        #region Environment Variables Operation
        /// <summary>
        /// Gets all environment variables for given variable type.
        /// </summary>
        /// <param name="varType">Type of the variable.</param>
        /// <returns></returns>
        public IDictionary GetEnvVariables(EnvironmentVariableTarget varType)
        {
            return Environment.GetEnvironmentVariables(varType);
        }

        public string ExpandEnvironmentVariable(string varName)
        {
            string varValue = Environment.ExpandEnvironmentVariables(varName);

            return varValue;
        }
        
        /// <summary>
        /// Gets the environment variable.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <param name="varType">Type of the variable.</param>
        /// <returns></returns>
        public string GetEnvironmentVariable(string varName, EnvironmentVariableTarget varType)
        {
            object objValue = shell.RegRead(RegistryKey(varType) + varName);
            
            return objValue.ToString();
        }

        /// <summary>
        /// Sets the environment variable.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <param name="varValue">The variable value.</param>
        /// <param name="varType">Type of the variable.</param>
        public void SetEnvironmentVariable(string varName, string varValue, EnvironmentVariableTarget varType)
        {
            ValidateVariables(varName, varValue);
            
            bool isRegExpandSz = varValue.Contains("%");

            SetVariable(RegistryKey(varType) + varName, varValue, isRegExpandSz); 
        }

        /// <summary>
        /// Gets the registry key for variable type.
        /// </summary>
        /// <param name="varType">Type of the variable.</param>
        /// <returns></returns>
        private string RegistryKey(EnvironmentVariableTarget varType)
        {
            return (varType == EnvironmentVariableTarget.User)
                ? USER_REGISTRY_KEY : SYSTEM_REGISTRY_KEY;
        }

        /// <summary>
        /// Deletes the environment variable.
        /// </summary>
        /// <param name="varName">Name of the var.</param>
        /// <param name="varType">Type of the var.</param>
        public void DeleteEnvironmentVariable(string varName, EnvironmentVariableTarget varType)
        {
            Environment.SetEnvironmentVariable(varName, null, varType);
        }   
        
        //
        // Thank you Greg Houston for a good solution
        // http://ghouston.blogspot.com/2005/08/how-to-create-and-change-environment.html
        /// <summary>
        /// Sets the variable.
        /// </summary>
        /// <param name="fullpath">The fullpath.</param>
        /// <param name="value">The value.</param>
        /// <param name="isRegExpandSz">if set to <c>true</c> [is reg expand sz].</param>
        private void SetVariable(string fullpath, string value, bool isRegExpandSz) 
        { 
            object objValue = value; 
            object objType = (isRegExpandSz) ? "REG_EXPAND_SZ" : "REG_SZ";  
            
            shell.RegWrite(fullpath, ref objValue, ref objType);
            
            int result; 
            SendMessageTimeout((System.IntPtr)HWND_BROADCAST, WM_SETTINGCHANGE, 
                0, "Environment", SMTO_BLOCK | SMTO_ABORTIFHUNG | SMTO_NOTIMEOUTIFNOTHUNG, 5000, out result);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SendMessageTimeout(IntPtr hWnd, int Msg, int wParam, 
            string lParam, int fuFlags, int uTimeout, out int lpdwResult); 
        
        public const int HWND_BROADCAST = 0xffff; 
        public const int WM_SETTINGCHANGE = 0x001A; 
        public const int SMTO_NORMAL = 0x0000; 
        public const int SMTO_BLOCK = 0x0001; 
        public const int SMTO_ABORTIFHUNG = 0x0002; 
        public const int SMTO_NOTIMEOUTIFNOTHUNG = 0x0008;
        #endregion Environment Variables Operation

        #region Validation
        /// <summary>
        /// Validates the variable.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <param name="varValue">The variable value.</param>
        private void ValidateVariables(string varName, string varValue)
        {
            if (string.IsNullOrEmpty(varName))
            {
                throw new Exception("Variable Name cannot be blank.");
            }
            if (varValue != null && varValue == "")
            {
                throw new Exception("Variable should have a value.");
            }
        }
        #endregion Validation   
    }
}

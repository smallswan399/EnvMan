/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2009 Vlad Setchin <envman-dev@googlegroups.com>

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

namespace EnvManager
{
    public class EnvVarManager
    {
        #region Environment Variables Operation
        public IDictionary GetEnvVariables(EnvironmentVariableTarget varType)
        {
            return Environment.GetEnvironmentVariables(varType);
        }

        public string GetEnvVariable(string varName, EnvironmentVariableTarget varType)
        {
            return Environment.GetEnvironmentVariable(varName, varType);
        }

        public void SetEnvironmentVariable(string varName, string varValue, EnvironmentVariableTarget varType)
        {
            ValidateVariables(varName, varValue);
            Environment.SetEnvironmentVariable(varName, varValue, varType);
        }

        public void DeleteEnvironmentVariable(string varName, EnvironmentVariableTarget varType)
        {
            SetEnvironmentVariable(varName, null, varType);
        }
        #endregion Environment Variables Operation

        #region Validation
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

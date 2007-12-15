/*
  EnvMan - The Open-Source Windows Environment Variables Manager
  Copyright (C) 2006-2007 Vlad Setchin <v_setchin@yahoo.com.au>

  This program is free software; you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation; either version 2 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EnvManager
{
    public enum EnvironmentValueType
	{
	    Number,
        String,
        Folder,
        File,
        Error
    }
    public class EnvVarValueValidator
    {
        public EnvironmentValueType ValueType(string varValue)
        {
            EnvironmentValueType type = EnvironmentValueType.String;
            if (IsNumber(varValue))
            {
                type = EnvironmentValueType.Number;
            }
            else if ( varValue.Contains( @":\" ) )
            {
                if ( System.IO.File.Exists( varValue ) )
                {
                    type = EnvironmentValueType.File;
                }
                else if ( System.IO.Directory.Exists( varValue ) )
                {
                    type = EnvironmentValueType.Folder;
                }
                else
                {
                    type = EnvironmentValueType.Error;
                }
            }

            return type;
        }

        // Function to test whether the string is valid number or not
        private bool IsNumber(string strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
                   !objTwoDotPattern.IsMatch(strNumber) &&
                   !objTwoMinusPattern.IsMatch(strNumber) &&
                   objNumberPattern.IsMatch(strNumber);
        }
    }
}

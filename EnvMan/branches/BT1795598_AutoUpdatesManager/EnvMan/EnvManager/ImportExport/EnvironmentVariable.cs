/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2007 Vlad Setchin <envmng@gmail.com>

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
using System.Xml.Serialization;

namespace EnvManager.ImportExport
{
    [Serializable]
    public class EnvironmentVariable
    {
        private const char SEPARATOR = ';';
        private string varName = "";
        private List<string> varValues = new List<string>();

        /// <summary>
        /// Gets or sets the name of the environment variable.
        /// </summary>
        /// <value>The name of the variable.</value>
        public string VarName
        {
            get { return varName; }
            set { varName = value; }
        }
        [XmlArray( "VariableValues" )]
        [XmlArrayItem( "Value", typeof( string ) )]
	    public List<string> VarValuesList
        {
            get
            {
                return varValues;
            }
            set
            {
                varValues.Clear();
                varValues = value;
            }
        }
        [XmlIgnore]
        public string VarValues
        {
            set
            {
                string[ ] values = value.Split( SEPARATOR );

                varValues.AddRange( values );
            }
        }
    }
}

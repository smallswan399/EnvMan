/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2008 Vlad Setchin <envmng@gmail.com>

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
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace EnvManager.ImportExport
{
    public class ImportExportManager
    {
        private EnvironmentVariable environmentVariable = null;

        public EnvironmentVariable EnvVariable
        {
            set
            {
                this.environmentVariable = value;
            }
            get
            {
                return this.environmentVariable;
            }
        }
        public void Save ( string filename )
        {
            //Create a file stream object
            FileStream file = File.Create( filename );

            //Start Serialization
            XmlSerializer xmlSerializer = new XmlSerializer( environmentVariable.GetType() );
            xmlSerializer.Serialize( file, environmentVariable );
            file.Close();
        }

        public void Load ( string filename )
        {
            try
            {
                //Create a file stream object
                FileStream file = File.OpenRead( filename );

                //Start Serialization
                XmlSerializer xmlSerializer = new XmlSerializer( environmentVariable.GetType() );
                environmentVariable = ( EnvironmentVariable ) xmlSerializer.Deserialize( file );

                file.Close();
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }
    }
}

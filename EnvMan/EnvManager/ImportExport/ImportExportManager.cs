//------------------------------------------------------------------------
// <copyright file="ImportExportManager.cs" company="SETCHIN Freelance Consulting">
// Copyright (C) 2006-2011 SETCHIN Freelance Consulting
// </copyright>
// <author>
// Vlad Setchin
// </author>
//------------------------------------------------------------------------

// EnvMan - The Open-Source Windows Environment Variables Manager
// Copyright (C) 2006-2011 SETCHIN Freelance Consulting 
// <http://www.setchinfc.com.au>
// EnvMan Development Group: <mailto:envman-dev@googlegroups.com>
//  
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace EnvManager.ImportExport
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Import Export Manager
    /// </summary>
    public class ImportExportManager
    {
        /// <summary>
        /// Environment Variable
        /// </summary>
        private EnvironmentVariable environmentVariable;

        /// <summary>
        /// Gets or sets the environment variable.
        /// </summary>
        /// <value>
        /// The environment variable.
        /// </value>
        public EnvironmentVariable EnvVariable
        {
            get
            {
                return this.environmentVariable;
            }

            set
            {
                this.environmentVariable = value;
            }
        }

        /// <summary>
        /// Saves the specified filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void Save(string filename)
        {
            // Create a file stream object
            FileStream file = File.Create(filename);

            // Start Serialization
            XmlSerializer xmlSerializer
                = new XmlSerializer(this.environmentVariable.GetType());
            xmlSerializer.Serialize(file, this.environmentVariable);
            file.Close();
        }

        /// <summary>
        /// Loads the specified filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void Load(string filename)
        {
            try
            {
                // Create a file stream object
                FileStream file = File.OpenRead(filename);

                // Start Serialization
                XmlSerializer xmlSerializer
                    = new XmlSerializer(this.environmentVariable.GetType());
                this.environmentVariable
                    = (EnvironmentVariable)xmlSerializer.Deserialize(file);

                file.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

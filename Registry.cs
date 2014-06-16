using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
namespace libplatform
{
    /// <summary>
    /// This is windows only functionality.  The registry does not exist on other platforms currently.
    /// </summary>
    public static class Registry
    {

        public static string RegisteredProgram(string ext)
        {
            const string extPathTemplate = @"HKEY_CLASSES_ROOT\{0}";
            const string cmdPathTemplate = @"HKEY_CLASSES_ROOT\{0}\shell\open\command";

            // 1. Find out document type name for .jpeg files

            var extPath = string.Format(extPathTemplate, ext);

            var docName = Microsoft.Win32.Registry.GetValue(extPath, string.Empty, string.Empty) as string;
            if (!string.IsNullOrEmpty(docName))
            {
                // 2. Find out which command is associated with our extension
                var associatedCmdPath = string.Format(cmdPathTemplate, docName);
                var associatedCmd = Microsoft.Win32.Registry.GetValue(associatedCmdPath, string.Empty, string.Empty) as string;
                if (!string.IsNullOrEmpty(associatedCmd))
                {
                    return associatedCmd;
                }
                else
                {
                    throw new NoRegisteredProgramException(ext);
                }
            }
            else
            {
                throw new NoRegisteredProgramException(ext);
            }
        }

        [global::System.Serializable]
        public class NoRegisteredProgramException : Exception
        {
            //
            // For guidelines regarding the creation of new exception types, see
            //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
            // and
            //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
            //

            public NoRegisteredProgramException() { }
            public NoRegisteredProgramException(string message) : base(message) { }
            public NoRegisteredProgramException(string message, Exception inner) : base(message, inner) { }
            protected NoRegisteredProgramException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }

        public static IEnumerable<string> RecommendedPrograms(string ext)
        {
            List<string> progs = new List<string>();

            string baseKey = @"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\." + ext;

            using (RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(baseKey + @"\OpenWithList"))
            {
                if (rk != null)
                {
                    string mruList = (string)rk.GetValue("MRUList");
                    if (mruList != null)
                    {
                        foreach (char c in mruList.ToString())
                            progs.Add(rk.GetValue(c.ToString()).ToString());
                    }
                }
            }

            using (RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(baseKey + @"\OpenWithProgids"))
            {
                if (rk != null)
                {
                    foreach (string item in rk.GetValueNames())
                        progs.Add(item);
                }
                //TO DO: Convert ProgID to ProgramName, etc.
            }

            return progs;
        }
    }
}

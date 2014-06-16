//Copyright (C) 2011, FIE LLC.

//See LICENSE.TXT for details.

using System;
using System.Diagnostics;
namespace libplatform
{
    /// <summary>
    /// Utility class.  Helps deal with platform detection and possibly platform specific functionality.
    /// We're not going to simplify this to the point that we just return an enumerated value for the platform.
    /// Instead, we're going to effectively provide the ability to ask questions about capabilities as much as possible.
    /// 
    /// Hence, not just "is_linux", "is_windows", "is_osx".
    /// But rather, "is_unix_style" "is_windows" "is_osx" "is_linux"
    /// </summary>
    public class CurrentPlatform
    {

        /// <summary>
        /// Returns true if the system is a unix styled system such as Linux, BSD or OSX.
        /// If "unix styled system" becomes ambiguous at some point, we'll need to modify this.
        /// </summary>
        /// <returns>
        /// A <see cref="System.Boolean"/>
        /// </returns>
        public static bool IsUnixStyle()
        {
            //yes, this is odd code.  check the explanation at the mono-project site for why.
            int p = (int)System.Environment.OSVersion.Platform;
            return (p == 4 || p == 6 || p == 128);
        }


        /// <summary>
        /// Returns true if the system is a Linux system.
        /// </summary>
        /// <returns>
        /// A <see cref="System.Boolean"/>
        /// </returns>
        public static bool IsLinux()
        {
            if (IsUnixStyle())
            {
				System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
				psi.FileName = "uname";
				psi.RedirectStandardOutput = true;
				psi.UseShellExecute = false;
                System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
                p.WaitForExit();
                string unameRet = p.StandardOutput.ReadLine();
                if (unameRet == "Darwin")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if the system is a Windows system.
        /// </summary>
        /// <returns>
        /// A <see cref="System.Boolean"/>
        /// </returns>
        public static bool IsWindows()
        {
            if (IsUnixStyle())
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// Returns true if the system is an OSX system.
        /// </summary>
        /// <returns>
        /// A <see cref="System.Boolean"/>
        /// </returns>
        public static bool IsOSX()
        {
            if (IsUnixStyle())
            {
				System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
				psi.FileName = "uname";
				psi.RedirectStandardOutput = true;
				psi.UseShellExecute = false;
                System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
                p.WaitForExit();
                string unameRet = p.StandardOutput.ReadLine();
                if (unameRet == "Darwin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
	
	
}


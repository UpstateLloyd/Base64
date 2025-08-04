using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Enumeration;
using System.Text;

namespace B64.Services
{
    class ConvertDXF
    {
        public string EncodeToBase64(string pngFilePath)
        {
            try
            {
                // Read the DXF file content into a byte array
                byte[] pngBytes = File.ReadAllBytes(pngFilePath);

                // Convert the byte array to a Base64 string
                string base64String = Convert.ToBase64String(pngBytes);

                return base64String;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file '{pngFilePath}' was not found.");
                return null;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return null;
            }
        }

        public bool ConvertDXFToPNG(string dxfPath, string pngPath)
        {
            string inkscapePath = @"C:\Program Files\Inkscape\bin\inkscape.exe";
            try 
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = inkscapePath,
                    Arguments = $"\"{dxfPath}\" --export-type=png --export-area-drawing --export-filename=\"{pngPath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        Console.WriteLine("Inkscape error output:");
                        Console.WriteLine(error);
                        return false;
                    }

                    Console.WriteLine("Inkscape output:");
                    Console.WriteLine(output);
                    return true;
                }            
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during conversion: {ex.Message}");
                return false;
            }
            
        }
    }
}

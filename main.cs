using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using EbiJALibrary;
namespace ConsoleApp1 {
	class Program {
		static unsafe void Main(string[] args) {
			if (args.Length < 1) {
				Console.WriteLine("Usage: " + "this" + " EBIX_PATH [OUT_PUT_DIR]");
				return;
			}
			string path = args[0];
			string outdir;
			if (args.Length > 1) outdir = args[1] + "\\";
			else outdir = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + "\\";
			Directory.CreateDirectory(outdir);
			var stopWatch = new Stopwatch();
            stopWatch.Start();
			/* Load .ebix with outer lib */
			var ebixBook = new EbixBook(path);
			var libraryVersion = ebixBook.LibraryVersion;
			var str = DateTime.Now.ToString("ssMMHHddmmyyyy", DateTimeFormatInfo.InvariantInfo);
			var encoding = Encoding.GetEncoding("Shift_JIS");
			var bytes = encoding.GetBytes(libraryVersion);
			var bytes2 = encoding.GetBytes("ebij" + str + "Cate");
			var array = new byte[bytes2.Length];
			ebixBook.ebijaCreateSeed(ref bytes, ref bytes2, out array);
			ebixBook.ebijaSeedInspection(ref array);
			/* Load .ebix Finished */
			Console.WriteLine("[*] Opened " + path);
            Parallel.For(0, ebixBook.PageCount, i =>
            {
				// Console.Write("[-] Extrating " + i.ToString() + ".jpg ");
				try {
					var page = ebixBook.Extract(i);
					var f = File.Open(outdir + i.ToString() + ".jpg", FileMode.Create, FileAccess.Write);
					page.CopyToAsync(f);
					// Console.WriteLine("Length:" + page.Length);
				} catch (Exception e) {
					Console.WriteLine("Fail: " + e);
				}
            });
			Console.WriteLine("[*] Done. Output at " + outdir);
            stopWatch.Stop();
            Console.WriteLine("[>] In " + stopWatch.ElapsedMilliseconds + " ms.");
		}
	}
}
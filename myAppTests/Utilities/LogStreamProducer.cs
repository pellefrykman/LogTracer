using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace myAppTests
{
    public class LogStreamProducer
    {
        private List<string> testLogEntries = new List<string>() {
            "Log entry 1",
            "Log entry 2",
            "Log entry 3",
            "Log entry 4",
            "Log entry 5",
        };

        public List<string> ISsLogEntries = new List<string>() {
            "2017-11-30 06:55:17.322 T5264 w_store_main - I1 identity: SODPRO21",
            "2017-11-30 06:55:17.323 T5264 w_store_main - I1 Refusing threaded stackstore due to non-image.",
            "2017-11-30 06:55:17.326 T5264 get_reqex_id - I1 Request number: 'SERSOD0000918837', Exam number: 'SERSOD0001171313'",
            "2017-11-30 06:55:17.341 T5264 wi/log_info2 - I1 Image put in bf_id: 13 ('sod2ads1'), rf_id: 15202276",
            "2017-11-30 06:55:17.504 T5264 wi/log_info3 - I1 ef_id: 23073422 and if_id: 162270620",
            @"2017-11-30 06:55:17.504 T5264 wi/copy_file - I1 Moving image
    from: E:\in_dcm/SODPRO21/1.2.752.24.7.112976771.1221110.6730031.0.20171129215620__1209855485.dcm
    to  : E:/sod2ads1/SERSOD0000918837/SERSOD0001171313/im_3/x0000.dcm",
            "2017-11-30 06:55:18.682 T5372 w_store_main - I1 identity: SODPRO21",
            "2017-11-30 06:55:18.682 T5372 w_store_main - I1 Refusing threaded stackstore due to non-image.",
            "2017-11-30 06:55:18.689 T5372 get_reqex_id - I1 Request number: 'SERSOD0000918837', Exam number: 'SERSOD0001171313'",
            "2017-11-30 06:55:18.710 T5372 wi/log_info2 - I1 Image put in bf_id: 13 ('sod2ads1'), rf_id: 15202276",
            "2017-11-30 06:55:18.803 T5372 wi/log_info3 - I1 ef_id: 23073422 and if_id: 162270622",
            @"2017-11-30 06:55:18.803 T5372 wi/copy_file - I1 Moving image
    from: E:\in_dcm/SODPRO21/1.2.752.24.7.112976771.1221110.6730032.0.20171129215620__1209856875.dcm
    to  : E:/sod2ads1/SERSOD0000918837/SERSOD0001171313/im_5/x0000.dcm",
            "2017-11-30 06:55:19.975 T1060 w_store_main - I1 identity: SODPRO21",
            "2017-11-30 06:55:19.976 T1060 w_store_main - I1 Refusing threaded stackstore due to non-image.",
            "2017-11-30 06:55:19.978 T1060 get_reqex_id - I1 Request number: 'SERSOD0000918837', Exam number: 'SERSOD0001171313'",
            "2017-11-30 06:55:19.992 T1060 wi/log_info2 - I1 Image put in bf_id: 13 ('sod2ads1'), rf_id: 15202276",
            "2017-11-30 06:55:20.081 T1060 wi/log_info3 - I1 ef_id: 23073422 and if_id: 162270624",
            @"2017-11-30 06:55:20.082 T1060 wi/copy_file - I1 Moving image
    from: E:\in_dcm/SODPRO21/1.2.752.24.7.112976771.1221110.6730030.0.20171130064411__1209858157.dcm
    to  : E:/sod2ads1/SERSOD0000918837/SERSOD0001171313/im_7/x0000.dcm",
            "2017-11-30 06:55:22.181 T2876 w_store_main - I1 identity: SODPRO21",
            "2017-11-30 06:55:22.182 T2876 w_store_main - I1 Refusing threaded stackstore due to non-image.",
            "2017-11-30 06:55:22.186 T2876 get_reqex_id - I1 Request number: 'SERSOD0000918845', Exam number: 'SERSOD0001171321'",
            "2017-11-30 06:55:22.197 T2876 wi/log_info2 - I1 Image put in bf_id: 13 ('sod2ads1'), rf_id: 15202277",
            "2017-11-30 06:55:22.247 T2876 wi/log_info3 - I1 ef_id: 23073423 and if_id: 162270629",
            @"2017-11-30 06:55:22.247 T2876 wi/copy_file - I1 Moving image
    from: E:\in_dcm/SODPRO21/1.2.752.24.7.112976771.1221121.6730167.0.20171130064535__1209860375.dcm
    to  : E:/sod2ads1/SERSOD0000918845/SERSOD0001171321/im_3/x0000.dcm",
            "2017-11-30 06:55:22.247 T2876 wi/log_info3 - I1 ef_id: 23073423 and if_id: 162270629",
        };

        private Timer timer;

        public void StartTestLogEntriesToStream(StreamWriter writer) {
            StartWriteLogLogEntriesToStream(writer, testLogEntries);
        }

        public void StartISsLogEntriesToStream(StreamWriter writer) {
            StartWriteLogLogEntriesToStream(writer, ISsLogEntries);
        }

        private void StartWriteLogLogEntriesToStream(StreamWriter writer, List<string> entries)
        {
            int i = 0;
            timer = new Timer(200);
            timer.Elapsed += (sender, e) => {
                writer.WriteLine(entries[i]);
                writer.Flush();
                i++;
                if (i >= entries.Count) {
                    timer.Stop();
                }
            };
            timer.Start();
        }

        public bool IsWriting() {
            return timer.Enabled;
        }
    }
}

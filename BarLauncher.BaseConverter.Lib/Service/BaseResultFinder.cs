using System;
using System.Collections.Generic;
using System.Linq;
using BarLauncher.EasyHelper;
using BarLauncher.EasyHelper.Core.Service;

namespace BarLauncher.BaseConverter.Lib.Service
{
    public class BaseResultFinder : BarLauncherResultFinder
    {
        public IBaseConvertService BaseConvertService { get; set; }
        public ISystemInformations SystemInformations { get; set; }
        public ISystemService SystemService { get; set; }

        private string _versionInformation = null;
        public string VersionInformation
        {
            get
            {
                if (_versionInformation == null)
                {
                    _versionInformation = "{0} version {1}".FormatWith(SystemInformations.ApplicationName, SystemInformations.Version);
                }
                return _versionInformation;
            }
        }

        public BaseResultFinder(IBarLauncherContextService barLauncherContextService, IBaseConvertService baseConvertService, ISystemInformations systemInformations, ISystemService systemService)
            : base(barLauncherContextService)
        {
            BaseConvertService = baseConvertService;
            SystemInformations = systemInformations;
            SystemService = systemService;
        }

        public override void Init()
        {
            base.Init();
            AddCommand("conv", "conv BASE1->BASE2 VALUE", "Convert VALUE expressed in base BASE1 to base BASE2", GetConvertResults);
            AddCommand("version", "version", VersionInformation, GetVersionResults);
            AddDefaultCommand(GetConvertResults);
        }

        public override void Dispose()
        {
            base.Dispose();
        }


        private string GetBaseName(string data)
        {
            switch (data)
            {
                case "2": return "binary";
                case "8": return "octal";
                case "10": return "decimal";
                case "16": return "hexadecimal";
                default:
                    return "base {0}".FormatWith(data);
            }
        }

        private BarLauncherResult GetCompletionResultForConvert(string baseOrig, string baseResult, string value)
        {
            string base1 = baseOrig == null ? "BASE1" : baseOrig;
            string base2 = baseResult == null ? "BASE2" : baseResult;

            string baseName1 = GetBaseName(base1);
            string baseName2 = GetBaseName(base2);

            string title = "conv {0}->{1} VALUE".FormatWith(base1, base2);
            string subTitle = "Convert VALUE expressed in {0} to {1}".FormatWith(baseName1, baseName2);

            if (baseOrig == null)
            {
                return GetCompletionResult(title, subTitle, ()=>"conv");
            }
            else
            {
                if (baseResult == null)
                {
                    return GetCompletionResultFinal(title, subTitle, () => "conv {0}->".FormatWith(base1));
                }
                else
                {
                    return GetCompletionResult(title, subTitle, () => "conv {0}->{1}".FormatWith(base1, base2));
                }
            }
        }
        private IEnumerable<BarLauncherResult> GetConvertResults(BarLauncherQuery query, int position)
        {
            var terms = query.GetSearchTermsStarting(position);
            if (terms.Count() == 0)
            {
                return new List<BarLauncherResult>()
                {
                    GetCompletionResultForConvert(null,null,null),
                    GetCompletionResultForConvert("2",null,null),
                    GetCompletionResultForConvert("10",null,null),
                    GetCompletionResultForConvert("16",null,null),
                };
            }
            else if (terms.Count() == 1)
            {
                string bases = terms.ElementAt(0);
                if (bases.Contains("->"))
                {
                    int indexSep = bases.IndexOf("->");
                    string base1 = bases.Substring(0, indexSep);
                    try
                    {
                        int base1Num = System.Convert.ToInt16(base1);
                    }
                    catch
                    {
                        return new List<BarLauncherResult>()
                        {
                            GetNoActionResult("conv BASE1->BASE2 VALUE","Error : BASE1 should be an integer")
                        };
                    }

                    string base2 = bases.Substring(indexSep + 2, bases.Length - indexSep - 2);
                    if (base2.Length == 0)
                    {
                        var result = new List<BarLauncherResult>();
                        result.Add(GetCompletionResultForConvert(base1, null, null));
                        if (base1 != "2")
                        {
                            result.Add(GetCompletionResultForConvert(base1, "2", null));
                        }
                        if (base1 != "10")
                        {
                            result.Add(GetCompletionResultForConvert(base1, "10", null));
                        }
                        if (base1 != "16")
                        {
                            result.Add(GetCompletionResultForConvert(base1, "16", null));
                        }
                        return result;
                    }
                    else
                    {
                        try
                        {
                            int base2Num = System.Convert.ToInt16(base2);
                            return new List<BarLauncherResult>()
                            {
                                GetCompletionResultForConvert(base1,base2,null),
                            };
                        }
                        catch
                        {
                            return new List<BarLauncherResult>()
                            {
                                GetNoActionResult("conv BASE1->BASE2 VALUE","Error : BASE2 should be an integer")
                            };
                        }
                    }
                }
                else
                {
                    string base1 = bases;
                    if (bases.EndsWith("-"))
                    {
                        base1 = bases.Substring(0, bases.Length-1);
                    }

                    try
                    {
                        int base1Num = System.Convert.ToInt16(base1);
                    }
                    catch
                    {
                        return new List<BarLauncherResult>()
                        {
                            GetNoActionResult("conv BASE1->BASE2 VALUE","Error : BASE1 should be an integer")
                        };
                    }

                    return new List<BarLauncherResult>()
                    {
                        GetCompletionResultForConvert(base1,null,null),
                    };
                }
            }
            else if (terms.Count() > 2)
            {
                return new List<BarLauncherResult>()
                {
                    GetNoActionResult("conv BASE1->BASE2 VALUE","Error : [{0}] is unexpected".FormatWith(string.Join(" ",terms.Skip(2).ToArray())))
                };
            }
            else
            {
                string bases = terms.ElementAt(0);
                string value = terms.ElementAt(1);
                if (bases.Contains("->"))
                {
                    int indexSep = bases.IndexOf("->");
                    string base1 = bases.Substring(0, indexSep);
                    int base1Num;
                    int base2Num;
                    try
                    {
                        base1Num = System.Convert.ToInt16(base1);
                    }
                    catch
                    {
                        return new List<BarLauncherResult>()
                        {
                            GetNoActionResult("conv BASE1->BASE2 VALUE","Error : BASE1 should be an integer")
                        };
                    }

                    string base2 = bases.Substring(indexSep + 2, bases.Length - indexSep - 2);
                    try
                    {
                        base2Num = System.Convert.ToInt16(base2);
                    }
                    catch
                    {
                        return new List<BarLauncherResult>()
                        {
                            GetNoActionResult("conv {0}->BASE2 VALUE".FormatWith(base1),"Error : BASE2 should be an integer")
                        };
                    }

                    try
                    {
                        string result = BaseConvertService.Convert(value, base1Num, base2Num);
                        return new List<BarLauncherResult>()
                        {
                            GetActionResult
                            (
                                "conv {0}->{1} {2} : {3}".FormatWith(base1, base2, value, result),
                                "[{2}] expressed in {0} correspond to [{3}] in {1}".FormatWith(GetBaseName(base1), GetBaseName(base2), value, result),
                                ()=>SystemService.CopyTextToClipboard(result)
                            )
                        };
                    }
                    catch (Exception e)
                    {
                        return new List<BarLauncherResult>()
                        {
                            GetNoActionResult("conv BASE1->BASE2 VALUE","Error : {0}".FormatWith(e.Message))
                        };
                    }
                }
                else
                {
                    return new List<BarLauncherResult>()
                    {
                        GetNoActionResult("conv BASE1->BASE2 VALUE", "Error : BASE1 and BASE2 should be present")
                    };
                }
            }
        }
        private IEnumerable<BarLauncherResult> GetVersionResults(BarLauncherQuery query, int position)
        {
            return new List<BarLauncherResult>()
            {
                new BarLauncherResult
                {
                    Title =VersionInformation,
                    SubTitle="Select to open project home page ({0})".FormatWith(SystemInformations.HomepageUrl),
                    Action=()=>SystemService.OpenUrl(SystemInformations.HomepageUrl),
                }
            };
        }

    }
}
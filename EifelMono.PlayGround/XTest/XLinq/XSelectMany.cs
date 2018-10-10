using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EifelMono.PlayGround.TestObjects;
using EifelMono.PlayGround.XCore;
using Xunit;
using Xunit.Abstractions;

namespace EifelMono.PlayGround.XTest.XLinq
{
    public class XSelectMany : XPlayGround
    {
        public XSelectMany(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void TestNotNull()
        {
            TryCatch(() =>
            {
                var testObject = new ClassA {
                    NameA = "A.1",
                    ClassBs = new List<ClassB> {
                        new ClassB {
                            NameB= "A1.B1",
                            ClassCs= new List<ClassC> {
                                new ClassC {
                                    NameC= "A1.B1.C1"
                                },
                                new ClassC {
                                    NameC= "A1.B1.C2"
                                },
                                 new ClassC {
                                    NameC= "A1.B1.C3"
                                },
                                new ClassC {
                                    NameC= "A1.B1.C4"
                                }
                            }
                        },
                        new ClassB {
                            NameB= "A1.B2",
                            ClassCs= new List<ClassC> {
                                new ClassC {
                                    NameC= "A1.B2.C1"
                                },
                                new ClassC {
                                    NameC= "A1.B2.C2"
                                }
                            }
                        },
                        new ClassB {
                            NameB= "A1.B3",
                            ClassCs= new List<ClassC> {
                                new ClassC {
                                    NameC= "A1.B3.C1"
                                },
                                new ClassC {
                                    NameC= "A1.B3.C2"
                                },
                                 new ClassC {
                                    NameC= "A1.B3.C3"
                                }
                            }
                        }
                    }
                };

                {
                    WriteLine("All NameC");
                    var items = testObject.ClassBs.SelectMany(b => b.ClassCs.Select(c => c.NameC)).Distinct();
                    foreach (var item in items)
                        Dump(item);
                }

                {
                    WriteLine("NameC.Contains(\"C1\")");
                    var items = testObject.ClassBs.SelectMany(b => b.ClassCs.Where(c => c.NameC.Contains("C1")).Select(c => c.NameC));
                    foreach (var item in items)
                        Dump(item);
                }
            });
        }


        [Fact]
        public void TestWithNull()
        {
            TryCatch(() =>
            {
                var testObject = new ClassA {
                    NameA = "A.1",
                    ClassBs = new List<ClassB> {
                    new ClassB {
                        NameB= "A1.B1",
                        ClassCs= new List<ClassC> {
                            new ClassC {
                                NameC= "A1.B1.C1"
                            },
                            new ClassC {
                                NameC= "A1.B1.C2"
                            },
                            null,
                            new ClassC {
                                NameC= "A1.B1.C4"
                            }
                        }
                    },
                    null,
                    new ClassB {
                        NameB= "A1.B3",
                        ClassCs= new List<ClassC> {
                            new ClassC {
                                NameC= "A1.B3.C1"
                            },
                            new ClassC {
                                NameC= "A1.B3.C2"
                            },
                            null,
                        }
                    }
                }
                };

                var items = testObject
                                .ClassBs
                                    .Where(b => b != null)
                                        .SelectMany(b => b.ClassCs
                                            .Where(c => c != null)
                                                .Select(c => c.NameC));

                foreach (var item in items)
                    Dump(item);
            });
        }

        [Fact]
        public void TestWithNull2()
        {
            TryCatch(() =>
            {
                var testObject = new ClassA {
                    NameA = "A.1",
                    ClassBs = new List<ClassB> {
                    new ClassB {
                        NameB= "A1.B1",
                        ClassCs= new List<ClassC> {
                            new ClassC {
                                NameC= "A1.B1.C1"
                            },
                            new ClassC {
                                NameC= "A1.B1.C2"
                            },
                            null,
                            new ClassC {
                                NameC= "A1.B1.C4"
                            }
                        }
                    },
                    null,
                    new ClassB {
                        NameB= "A1.B3",
                        ClassCs= new List<ClassC> {
                            new ClassC {
                                NameC= "A1.B3.C1"
                            },
                            new ClassC {
                                NameC= "A1.B3.C2"
                            },
                            null,
                        }
                    }
                }
                };

                var items = testObject
                                .ClassBs
                                    .Where(b => b != null)
                                        .SelectMany(b => b.ClassCs)
                                            .Where(c => c != null)
                                                .Select(c => c.NameC);

                foreach (var item in items)
                    Dump(item);
            });
        }


        [Fact]
        public void TestWithNull3()
        {
            TryCatch(() =>
            {
                var testObject = new ClassA {
                    NameA = "A.1",
                    ClassBs = new List<ClassB> {
                    new ClassB {
                        NameB= "A1.B1",
                        ClassCs= new List<ClassC> {
                            new ClassC {
                                NameC= "A1.B1.C1"
                            },
                            new ClassC {
                                NameC= "A1.B1.C2"
                            },
                            null,
                            new ClassC {
                                NameC= "A1.B1.C4"
                            }
                        }
                    },
                    null,
                    new ClassB {
                        NameB= "A1.B3",
                        ClassCs= new List<ClassC> {
                            new ClassC {
                                NameC= "A1.B3.C1"
                            },
                            new ClassC {
                                NameC= "A1.B3.C2"
                            },
                            null,
                        }
                    }
                }
                };

                var items = testObject.ClassBs.NotNull().SelectMany(b => b.ClassCs).NotNull().Select(c => c.NameC);

                foreach (var item in items)
                    Dump(item);
            });
        }

        [Fact]
        public void TestWithNull3A()
        {
            TryCatch(() =>
            {
                var testObject = new ClassA {
                    NameA = "A.1",
                    ClassBs = new List<ClassB> {
                    new ClassB {
                        NameB= "A1.B1",
                        ClassCs= new List<ClassC> {
                            new ClassC {
                                NameC= "A1.B1.C1"
                            },
                            new ClassC {
                                NameC= "A1.B1.C2"
                            },
                            null,
                            new ClassC {
                                NameC= "A1.B1.C4"
                            }
                        }
                    },
                    null,
                    new ClassB {
                        NameB= "A1.B3",
                        ClassCs= new List<ClassC> {
                            new ClassC {
                                NameC= "A1.B3.C1"
                            },
                            new ClassC {
                                NameC= "A1.B3.C2"
                            },
                            null,
                        }
                    }
                }
                };

                var items = testObject.ClassBs.SelectManyNN(b => b.ClassCs).SelectNN(c => c.NameC);

                foreach (var item in items)
                    Dump(item);
            });
        }

    }

   

}

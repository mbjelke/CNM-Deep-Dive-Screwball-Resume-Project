using ScrewballResume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewballResume.Data
{
    public class GoSeedYourself
    {

        public static void Initialize(ResumeContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Applicants, and kill them
            // Dispose of the evidence in the woods
            if (context.Applicants.Any())
            {
                foreach (var applicant1 in context.Applicants)
                { context.Applicants.Remove(applicant1); }

                foreach (var job in context.Jobs)
                { context.Jobs.Remove(job); }

                foreach (var accomplishment in context.Accomplishments)
                { context.Accomplishments.Remove(accomplishment); }

                foreach (var qualification in context.Qualifications)
                { context.Qualifications.Remove(qualification); }

                foreach (var affiliation in context.Affiliations)
                { context.Affiliations.Remove(affiliation); }

                foreach (var certification in context.Certifications)
                { context.Certifications.Remove(certification); }

                context.SaveChanges();
            }

            // 1 Applicant and 3 references. You should call the numbers. They're funny. 
            // And the indenting? Horrible.
            var applicant = new Applicant[]
            {
                new Applicant
                {
                    FirstName ="Heywood",
                    LastName ="Jablomie",
                    Phone ="605-475-6968",
                    Email ="cek39298@tqosi.com",
                    Address1 ="123 Fakerville Drive",
                    Address2="",
                    City = "Tillet Hertz",
                    State = "OH",
                    Zip = "54321",
                    Website="http://www.lorizzle.nl",
                    LinkedIn = "http://www.linkedin.com",
                    Facebook = "http://www.facebook.com",
                    Twitter = "http://www.twitter.com",
                    ProfessionalStatement ="Morbi sizzle. Dawg potenti. Its fo rizzle fo. Gangster elizzle shizzlin dizzle, ullamcorpizzle quis, ullamcorpizzle phat, scelerisque brizzle, fo shizzle my nizzle. Crunk fo shizzle dang. Break yo neck, yall felizzle.",
                },

                                new Applicant
                {
                    FirstName ="Dixie",
                    LastName ="Normous",
                    Phone ="605-475-6968",
                    Email ="cek39298@tqosi.com",
                    Address1 ="456-A Bendover Drive",
                    Address2="",
                    City = "Ankh Morpork",
                    State = "AK",
                    Zip = "12345",
                    Website="https://hipsum.co/",
                    LinkedIn = "http://www.linkedin.com",
                    Facebook = "http://www.facebook.com",
                    Twitter = "http://www.twitter.com",
                    ProfessionalStatement ="Kombucha artisan fanny pack pabst craft beer lumbersexual, bitters banjo cred skateboard asymmetrical man braid flannel. Subway tile fanny pack ugh craft beer waistcoat, chicharrones mumblecore brooklyn street art pork belly. Tofu vape readymade forage skateboard. La croix hashtag yuccie, chambray bitters green juice viral freegan roof party paleo poutine post-ironic heirloom offal. You probably haven't heard of them blog flannel meditation neutra four dollar toast synth next level. Brunch vinyl vegan chillwave. Four dollar toast kogi godard fingerstache cred fixie selvage DIY direct trade ramps. Prism squid aesthetic subway tile normcore trust fund affogato. Chartreuse flannel skateboard fingerstache, schlitz kale chips street art adaptogen tumeric williamsburg unicorn stumptown hammock. Cloud bread pinterest butcher, flannel gastropub shabby chic mumblecore +1 DIY air plant freegan biodiesel woke wolf. Roof party vexillologist meh mlkshk. Tumeric DIY asymmetrical raw denim, slow-carb shaman ennui cronut hot chicken hoodie.",
                },


            };

            foreach (Applicant a in applicant)
            {
                context.Applicants.Add(a);

            }

            context.SaveChanges();

            // Would help if there were a few Jobs listed.  What the hell. 
            var jobs = new Job[]
            {
                    new Job
                    {
						// For more info http://www.lifebuzz.com/funny-business/ #2
						Company ="Donkey Balls",
                        Title="Chocolate Nutter",
                        Location = "Kona, HI",
                        FromYear = "2018",
                        ToYear = "",
                        IsCurrent =true,
                        Description="This is a real shop in Kona, Hawaii that specializes in chocolate covered nuts.",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Jablomie").ID,
                    },

                    new Job
                    {
						// For more info 
						Company ="Anal Tech",
                        Title="Technician, obviously",
                        Location = "Newark, DE",
                        FromYear = "2016",
                        ToYear = "2017",
                        IsCurrent =false,
                        Description="This is a real company located in Newark, DE. I don't know what they do, and I'm kind of afraid to Google it.",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Jablomie").ID,
                    },


                                      new Job
                    {
						// For more info https://moosylvania.com/
						Company ="Moosylvania",
                        Title="Brander of Brands",
                        Location = "Saint Louis, MO",
                        FromYear = "2012",
                        ToYear = "2013",
                        IsCurrent =false,
                        Description="This is a real company located in Saint Louis, MO. They help create brand recognition.",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Normous").ID,
                    },

            };
            foreach (Job j in jobs)
            {
                context.Jobs.Add(j);
            }

            context.SaveChanges();



            // Have some Accomplishments!
            var accomplishments = new Accomplishment[]
            {
                    new Accomplishment
                    {
                        Accomp = "Did not kill the psychopath.",
						//Applicant = applicant
						JobID  = jobs
                            .Single( a => a.Company == "Anal Tech").JobID,
                    },

                    new Accomplishment
                    {
                        Accomp = "Managed not to steal co-workers' lunches.",
						//Applicant = applicant
						JobID  = jobs
                            .Single( a => a.Company == "Anal Tech").JobID,
                    },

                    new Accomplishment
                    {
                        Accomp = "Neglected to omit confession from resume.",
						//Applicant = applicant
						JobID  = jobs
                            .Single( a => a.Company == "Donkey Balls").JobID,
                    },
                    new Accomplishment
                    {
                        Accomp = "Removed all evidence from truck, chainsaw, and created perfect alibi.",
						//Applicant = applicant
						JobID  = jobs
                            .Single( a => a.Company == "Donkey Balls").JobID,
                    },
                    new Accomplishment
                    {
                        Accomp = "Dismembered victim with chainsaw in deep woods, no witnesses",
						//Applicant = applicant
						JobID  = jobs
                            .Single( a => a.Company == "Donkey Balls").JobID,
                    },
                    new Accomplishment
                    {
                        Accomp = "Killed the psychopath.",
						//Applicant = applicant
						JobID  = jobs
                            .Single( a => a.Company == "Donkey Balls").JobID,
                    },

                     new Accomplishment
                    {
                        Accomp = "Be the psychopath.",
						//Applicant = applicant
						JobID  = jobs
                            .Single( a => a.Company == "Moosylvania").JobID,
                    },



            };
            foreach (Accomplishment a in accomplishments)
            {
                context.Accomplishments.Add(a);
            }

            context.SaveChanges();


            // I can has Qualifications
            var qualifications = new Qualification[]
            {
                    new Qualification
                    {
                        Skill ="Inherent hatred for the variable FirstMidName",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Jablomie").ID,
                                            },
                    new Qualification
                    {
                        Skill ="Really bendy thumb",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Jablomie").ID,
                    },
                    new Qualification
                    {
                        Skill ="Can tie a cherry stem into a knot without using my hands",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Jablomie").ID,
                    },
                    new Qualification
                    {
                        Skill ="(expletive omitted)",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Jablomie").ID,
                    },
                    new Qualification
                    {
                        Skill ="Can hold 17 eggs in one hand",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Normous").ID,
                                            },
                    new Qualification
                    {
                        Skill ="Grate communication and atettntion to detailfs",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Normous").ID,
                                            },
                                };
            foreach (Qualification q in qualifications)
            {
                context.Qualifications.Add(q);
            }

            context.SaveChanges();


            // Are you Ailliated?  I are Affiliated.
            var affiliations = new Affiliation[]
            {
					//Read more: http://metro.co.uk/2015/05/11/here-are-5-of-the-most-ridiculous-clubs-ever-conceived-5191299/#ixzz4lM8jgQdC
					new Affiliation
                    {
                        AffilOrg ="The Not Terribly Good Club of Great Britain",
                        Role ="VP of Fake British Accents",
                        Type ="For Profit",
                        From ="1982",
                        To ="",
                        IsCurrent =true,
                        AffilURL = "http://metro.co.uk/2015/05/11/here-are-5-of-the-most-ridiculous-clubs-ever-conceived-5191299/#ixzz4lM8jgQdC",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Jablomie").ID,
                    },
					//Read more: http://www.therichest.com/rich-list/most-popular/10-of-the-weirdest-clubs-associations-you-could-ever-join/
					new Affiliation
                    {
                        AffilOrg ="The Gormogons And The Scald-Miserables",
                        Role ="Voting Director, Hegemon",
                        Type ="Not For Profit",
                        From ="1997",
                        To ="",
                        IsCurrent =true,
                        AffilURL = "http://www.therichest.com/rich-list/most-popular/10-of-the-weirdest-clubs-associations-you-could-ever-join/",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Normous").ID,
                    },
					// Read more:http://www.huffingtonpost.com/the-daily-meal/most-ridiculous-bar-names_b_937151.html?slideshow=true#gallery/189200/2
					new Affiliation
                    {
                        AffilOrg ="La Merde Lounge",
                        Role ="President and Chief Poopsmith",
                        Type ="Dive Bar",
                        From ="2015",
                        To ="2017",
                        IsCurrent =false,
                        AffilURL = "http://www.huffingtonpost.com/the-daily-meal/most-ridiculous-bar-names_b_937151.html?slideshow=true#gallery/189200/2",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Jablomie").ID,
                    },

            };
            foreach (Affiliation a in affiliations)
            {
                context.Affiliations.Add(a);
            }
            context.SaveChanges();


            // Certifiable!  Sointenly!
            // And perhaps a Certification or two
            var certifications = new Certification[]
            {
                new Certification
                    {
                        CertName ="Home Entertainment Installer",
                        CertAuthority ="State of Connecticut",
                        LicenseNum ="7",
                        From =DateTime.Parse("09/01/2007"),
                        To =DateTime.Parse("09/01/2099"),
                        IsEternal =true,
                        CertURL ="https://www.thestreet.com/story/12902141/7/license-to-shampoo-12-most-ridiculous-required-professional-certifications.html",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Jablomie").ID,
                    },

                new Certification
                    {
                        CertName ="Zumba Instructor",
                        CertAuthority ="Defined Fitness",
                        LicenseNum ="321Foad",
                        From =DateTime.Parse("09/01/2007"),
                        To =DateTime.Parse("09/01/2099"),
                        IsEternal =true,
                        CertURL ="http://b.vimeocdn.com/ps/256/839/2568392_300.jpg",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Jablomie").ID,
                    },

                                new Certification
                    {
                        CertName ="Bad Ass",
                        CertAuthority ="",
                        LicenseNum ="",
                        From =DateTime.Parse("09/01/1952"),
                        To =DateTime.Parse("09/01/2099"),
                        IsEternal =true,
                        CertURL ="https://img1.etsystatic.com/133/0/11991015/il_340x270.1105480625_oir4.jpg",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Normous").ID,
                    },
            };

            foreach (Certification c in certifications)
            {
                context.Certifications.Add(c);
            }

            context.SaveChanges();

            // Don't forget about the educations. Because educations is the plural of Education. It's not a stupid word AT ALL.
            var educations = new Education[]
            {
                    new Education
                    {
						// For more info http://www.oddee.com/item_97530.aspx
						OrgName ="The Porny School",
                        Location="Online where no one can see you",
                        From = ("2007"),
                        To = ("2099"),
                        isCurrent =true,
                        DegreeAttained="Blackbelt",
                        ConcentrationIn="Kicking Ass",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Jablomie").ID,
                    },

                    new Education
                    {
						// for more info see http://www.oddee.com/item_97530.aspx
						OrgName ="West Fukusimi Titnipple High",
                        Location="West Fukusimi, Japan",
                        From = ("2001"),
                        To =("2001"),
                        isCurrent =true,
                        DegreeAttained="Master of Mastery",
                        ConcentrationIn = "Taking Names",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Jablomie").ID,
                    },

                    new Education
                    {
						// for more info see http://www.oddee.com/item_97530.aspx
						OrgName ="West Fukusimi Titnipple High",
                        Location="West Fukusimi, Japan",
                        From = ("2001"),
                        To =("2001"),
                        isCurrent =true,
                        DegreeAttained="Doctor of Philosophy",
                        ConcentrationIn = "Talking my way out of speeding tickets",
						//Applicant = applicant
						ApplicantID  = applicant
                            .Single( a => a.LastName == "Normous").ID,
                    },
            };
            foreach (Education e in educations)
            {
                context.Educations.Add(e);
            }

            context.SaveChanges();

            // 3 references. Call the numbers, why dontcha. They're funny. 

            var references = new Reference[]
            {

                new Reference
                {
                    FirstName = "Yolanda",
                    LastName = "Squatpump",
                    Phone = "866-740-4531",
                    Email = "cek39298@tqosi.com",
                    ReferenceDesc = "Alter Ego",
					//Applicant = applicant
					ApplicantID  = applicant
                        .Single( a => a.LastName == "Jablomie").ID,
                },
                new Reference
                {
                    FirstName = "Moe",
                    LastName = "Lester",
                    Phone = "206-569-5829",
                    Email = "cek39298@tqosi.com",
                    ReferenceDesc = "Formerly Relevant Individual",
					//Applicant = applicant
					ApplicantID  = applicant
                            .Single( a => a.LastName == "Normous").ID,

                },
                new Reference
                {
                    FirstName = "Justin",
                    LastName = "Sider",
                    Phone = "1-888-447-5594",
                    Email = "cek39298@tqosi.com",
                    ReferenceDesc = "Next Contestant",
					//Applicant = applicant
					ApplicantID  = applicant
                            .Single( a => a.LastName == "Jablomie").ID,

                }

            };
            foreach (Reference r in references)
            {
                context.References.Add(r);
            }

            context.SaveChanges();

        }
    }
}


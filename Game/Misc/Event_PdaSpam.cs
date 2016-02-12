// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Event_PdaSpam : Event {

		public int time_failed = 0;
		public Obj_Machinery_MessageServer useMS = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.endWhen = 900;
		}

		public Event_PdaSpam ( Obj_Item_MechaParts_MechaEquipment_Tool_CableLayer tlistener = null, string tprocname = null ) : base( tlistener, tprocname ) {
			
		}

		// Function from file: money_spam.dm
		public override void tick(  ) {
			Obj_Machinery_MessageServer MS = null;
			dynamic P = null;
			ByTable viables = null;
			Game_Data check_pda = null;
			dynamic filter_app = null;
			string sender = null;
			string message = null;
			Mob_Living_Silicon_Ai ai = null;
			dynamic O = null;
			dynamic L = null;

			
			if ( !( this.useMS != null ) || !this.useMS.active ) {
				this.useMS = null;

				if ( GlobalVars.message_servers != null ) {
					
					foreach (dynamic _a in Lang13.Enumerate( GlobalVars.message_servers, typeof(Obj_Machinery_MessageServer) )) {
						MS = _a;
						

						if ( MS.active ) {
							this.useMS = MS;
							break;
						}
					}
				}
			}

			if ( this.useMS != null ) {
				this.time_failed = Game13.time;

				if ( Rand13.PercentChance( 2 ) ) {
					P = null;
					viables = new ByTable();

					foreach (dynamic _b in Lang13.Enumerate( GlobalFuncs.sortNames( GlobalVars.PDAs ), typeof(Obj_Item_Device_Pda) )) {
						check_pda = _b;
						

						if ( !Lang13.Bool( ((dynamic)check_pda).owner ) || Lang13.Bool( ((dynamic)check_pda).toff ) || check_pda == this || Lang13.Bool( ((dynamic)check_pda).hidden ) ) {
							continue;
						}
						viables.Add( check_pda );
					}

					if ( !( viables.len != 0 ) ) {
						return;
					}
					P = Rand13.PickFromTable( viables );
					filter_app = Lang13.FindIn( typeof(PdaApp_SpamFilter), P.applications );

					if ( Lang13.Bool( filter_app ) && Convert.ToInt32( filter_app.function ) == 2 ) {
						return;
					}
					sender = null;
					message = null;

					dynamic _c = Rand13.Pick(new object [] { 1, 2, 3, 4, 5, 6, 7 }); // Was a switch-case, sorry for the mess.
					if ( _c==1 ) {
						sender = Rand13.Pick(new object [] { "MaxBet", "MaxBet Online Casino", "There is no better time to register", "I'm excited for you to join us" });
						message = Rand13.Pick(new object [] { "Triple deposits are waiting for you at MaxBet Online when you register to play with us.", "You can qualify for a 200% Welcome Bonus at MaxBet Online when you sign up today.", "Once you are a player with MaxBet, you will also receive lucrative weekly and monthly promotions.", "You will be able to enjoy over 450 top-flight casino games at MaxBet." });
					} else if ( _c==2 ) {
						sender = Rand13.PickWeighted(new object [] { 30246, "QuickDatingSystem", 50410, "Find your russian bride", 55451, "Tajaran beauties are waiting", 60492, "Find your secret skrell crush", 65535, "Beautiful unathi brides" });
						message = Rand13.Pick(new object [] { "Your profile caught my attention and I wanted to write and say hello (QuickDating).", "If you will write to me on my email " + Rand13.PickFromTable( GlobalVars.first_names_female ) + "@" + Rand13.PickFromTable( GlobalVars.last_names ) + "." + Rand13.Pick(new object [] { "ru", "ck", "tj", "ur", "nt" }) + " I shall necessarily send you a photo (QuickDating).", "I want that we write each other and I hope, that you will like my profile and you will answer me (QuickDating).", "You have (1) new message!", "You have (2) new profile views!" });
					} else if ( _c==3 ) {
						sender = Rand13.Pick(new object [] { "Galactic Payments Association", "Better Business Bureau", "Tau Ceti E-Payments", "Nanotrasen Finance Department", "Luxury Replicas" });
						message = Rand13.Pick(new object [] { "Luxury watches for Blowout sale prices!", "Watches, Jewelry & Accessories, Bags & Wallets !", "Deposit 100$ and get 300$ totally free!", " 100K NT.|WOWGOLD ï¿½nly $89            <HOT>", "We have been filed with a complaint from one of your customers in respect of their business relations with you.", "We kindly ask you to open the COMPLAINT REPORT (attached) to reply on this complaint.." });
					} else if ( _c==4 ) {
						sender = Rand13.Pick(new object [] { "Buy Dr. Maxman", "Having dysfuctional troubles?" });
						message = Rand13.Pick(new object [] { "DR MAXMAN: REAL Doctors, REAL Science, REAL Results!", "Dr. Maxman was created by George Acuilar, M.D, a CentComm Certified Urologist who has treated over 70,000 patients sector wide with 'male problems'.", "After seven years of research, Dr Acuilar and his team came up with this simple breakthrough male enhancement formula.", "Men of all species report AMAZING increases in length, width and stamina." });
					} else if ( _c==5 ) {
						sender = Rand13.Pick(new object [] { "Dr", "Crown prince", "King Regent", "Professor", "Captain" });
						sender += " " + Rand13.Pick(new object [] { "Robert", "Alfred", "Josephat", "Kingsley", "Sehi", "Zbahi" }) + " " + Rand13.Pick(new object [] { "Mugawe", "Nkem", "Gbatokwia", "Nchekwube", "Ndim", "Ndubisi" });
						message = Rand13.Pick(new object [] { "YOUR FUND HAS BEEN MOVED TO " + Rand13.Pick(new object [] { "Salusa", "Segunda", "Cepheus", "Andromeda", "Gruis", "Corona", "Aquila", "Asellus" }) + " DEVELOPMENTARY BANK FOR ONWARD REMITTANCE.", "We are happy to inform you that due to the delay, we have been instructed to IMMEDIATELY deposit all funds into your account", "Dear fund beneficiary, We have please to inform you that overdue funds payment has finally been approved and released for payment", "Due to my lack of agents I require an off-world financial account to immediately deposit the sum of 1 POINT FIVE MILLION credits.", "Greetings sir, I regretfully to inform you that as I lay dying here due to my lack ofheirs I have chosen you to recieve the full sum of my lifetime savings of 1.5 billion credits" });
					} else if ( _c==6 ) {
						sender = Rand13.Pick(new object [] { "Nanotrasen Morale Divison", "Feeling Lonely?", "Bored?", "www.wetskrell.nt" });
						message = Rand13.Pick(new object [] { "The Nanotrasen Morale Division wishes to provide you with quality entertainment sites.", "WetSkrell.nt is a xenophillic website endorsed by NT for the use of male crewmembers among it's many stations and outposts.", "Wetskrell.nt only provides the higest quality of male entertaiment to Nanotrasen Employees.", "Simply enter your Nanotrasen Bank account system number and pin. With three easy steps this service could be yours!" });
					} else if ( _c==7 ) {
						sender = Rand13.Pick(new object [] { "You have won free tickets!", "Click here to claim your prize!", "You are the 1000th vistor!", "You are our lucky grand prize winner!" });
						message = Rand13.Pick(new object [] { "You have won tickets to the newest ACTION JAXSON MOVIE!", "You have won tickets to the newest crime drama DETECTIVE MYSTERY IN THE CLAMITY CAPER!", "You have won tickets to the newest romantic comedy 16 RULES OF LOVE!", "You have won tickets to the newest thriller THE CULT OF THE SLEEPING ONE!" });
					}
					this.useMS.send_pda_message( "" + P.owner, sender, message );

					if ( Rand13.PercentChance( 50 ) ) {
						
						foreach (dynamic _d in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living_Silicon_Ai) )) {
							ai = _d;
							

							if ( ai.aiPDA != P && ai.aiPDA != this ) {
								ai.show_message( "<i>Intercepted message from <b>" + sender + "</b></i> (Unknown) <i>to <b>" + P.owner + "</b>: " + message + "</i>" );
							}
						}
					}
					P.tnote += "<i><b>&larr; From " + sender + " (Unknown):</b></i><br>" + message + "<br>";

					if ( !Lang13.Bool( filter_app ) || Lang13.Bool( filter_app.function ) == false ) {
						
						if ( !Lang13.Bool( P.silent ) ) {
							GlobalFuncs.playsound( P.loc, "sound/machines/twobeep.ogg", 50, 1 );
						}

						foreach (dynamic _e in Lang13.Enumerate( Map13.FetchHearers( P.loc, 3 ) )) {
							O = _e;
							

							if ( !Lang13.Bool( P.silent ) ) {
								O.show_message( new Txt().icon( P ).str( " *" ).item( P.ttone ).str( "*" ).ToString() );
							}
						}
					}
					L = null;

					if ( P.loc != null && P.loc is Mob_Living ) {
						L = P.loc;
					} else {
						L = GlobalFuncs.get( P, typeof(Mob_Living_Silicon) );
					}

					if ( Lang13.Bool( L ) && ( !Lang13.Bool( filter_app ) || Lang13.Bool( filter_app.function ) == false ) ) {
						GlobalFuncs.to_chat( L, new Txt().icon( P ).str( " <b>Message from " ).item( sender ).str( " (Unknown), </b>\"" ).item( message ).str( "\" (<a href='byond://?src=" ).Ref( this ).str( ";choice=Message;skiprefresh=1;target=" ).Ref( this ).str( "'>Reply</a>)" ).ToString() );
					}
				}
			} else if ( Game13.time > this.time_failed + 1200 ) {
				this.kill();
			}
			return;
		}

		// Function from file: money_spam.dm
		public override void setup(  ) {
			Obj_Machinery_MessageServer MS = null;

			this.time_failed = Game13.time;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.message_servers, typeof(Obj_Machinery_MessageServer) )) {
				MS = _a;
				

				if ( MS.active ) {
					this.useMS = MS;
					break;
				}
			}
			return;
		}

	}

}
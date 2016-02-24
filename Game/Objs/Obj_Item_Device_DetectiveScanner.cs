// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_DetectiveScanner : Obj_Item_Device {

		public bool scanning = false;
		public ByTable log = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "electronic";
			this.flags = 68;
			this.slot_flags = 512;
			this.origin_tech = "engineering=3;biotech=2";
			this.icon_state = "forensicnew";
		}

		public Obj_Item_Device_DetectiveScanner ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: scanner.dm
		public void add_log( string msg = null, bool? broadcast = null ) {
			broadcast = broadcast ?? true;

			Ent_Static M = null;

			
			if ( this.scanning ) {
				
				if ( broadcast == true && this.loc is Mob ) {
					M = this.loc;
					((dynamic)M).WriteMsg( msg );
				}
				this.log.Add( "&nbsp;&nbsp;" + msg );
			} else {
				Task13.Crash( new Txt().item( this ).str( " " ).Ref( this ).str( " is adding a log when it was never put in scanning mode!" ).ToString() );
			}
			return;
		}

		// Function from file: scanner.dm
		public void scan( dynamic A = null, dynamic user = null ) {
			ByTable fingerprints = null;
			ByTable blood = null;
			ByTable fibers = null;
			ByTable reagents = null;
			string target_name = null;
			dynamic H = null;
			Reagent R = null;
			dynamic blood_DNA = null;
			dynamic blood_type = null;
			bool found_something = false;
			dynamic finger = null;
			dynamic B = null;
			dynamic fiber = null;
			dynamic R2 = null;
			Ent_Static holder = null;

			
			if ( !this.scanning ) {
				
				if ( !( Map13.GetDistance( A, user ) <= 1 ) && !Map13.FetchInView( user, Game13.view ).Contains( A ) ) {
					return;
				}

				if ( this.loc != user ) {
					return;
				}
				this.scanning = true;
				((Ent_Static)user).visible_message( new Txt().The( user ).item().str( " points the " ).item( this.name ).str( " at " ).the( A ).item().str( " and performs a forensic scan." ).ToString() );
				user.WriteMsg( new Txt( "<span class='notice'>You scan " ).the( A ).item().str( ". The scanner is now analysing the results...</span>" ).ToString() );
				fingerprints = new ByTable();
				blood = new ByTable();
				fibers = new ByTable();
				reagents = new ByTable();
				target_name = A.name;

				if ( A.blood_DNA != null && A.blood_DNA.len != 0 ) {
					blood = A.blood_DNA.Copy();
				}

				if ( A.suit_fibers != null && A.suit_fibers.len != 0 ) {
					fibers = A.suit_fibers.Copy();
				}

				if ( A is Mob_Living_Carbon_Human ) {
					H = A;

					if ( !Lang13.Bool( H.gloves ) ) {
						fingerprints.Add( Num13.Md5( H.dna.uni_identity ) );
					}
				} else if ( !( A is Mob ) ) {
					
					if ( A.fingerprints != null && A.fingerprints.len != 0 ) {
						fingerprints = A.fingerprints.Copy();
					}

					if ( Lang13.Bool( A.reagents ) && A.reagents.reagent_list.len != 0 ) {
						
						foreach (dynamic _a in Lang13.Enumerate( A.reagents.reagent_list, typeof(Reagent) )) {
							R = _a;
							
							reagents[R.name] = R.volume;

							if ( R is Reagent_Blood ) {
								
								if ( Lang13.Bool( R.data["blood_DNA"] ) && Lang13.Bool( R.data["blood_type"] ) ) {
									blood_DNA = R.data["blood_DNA"];
									blood_type = R.data["blood_type"];
									blood[blood_DNA] = blood_type;
								}
							}
						}
					}
				}
				Task13.Schedule( 0, (Task13.Closure)(() => {
					found_something = false;
					this.add_log( "<B>" + GlobalFuncs.worldtime2text() + GlobalFuncs.get_timestamp() + " - " + target_name + "</B>", false );

					if ( fingerprints != null && fingerprints.len != 0 ) {
						Task13.Sleep( 30 );
						this.add_log( "<span class='info'><B>Prints:</B></span>" );

						foreach (dynamic _b in Lang13.Enumerate( fingerprints )) {
							finger = _b;
							
							this.add_log( "" + finger );
						}
						found_something = true;
					}

					if ( blood != null && blood.len != 0 ) {
						Task13.Sleep( 30 );
						this.add_log( "<span class='info'><B>Blood:</B></span>" );
						found_something = true;

						foreach (dynamic _c in Lang13.Enumerate( blood )) {
							B = _c;
							
							this.add_log( "Type: <font color='red'>" + blood[B] + "</font> DNA: <font color='red'>" + B + "</font>" );
						}
					}

					if ( fibers != null && fibers.len != 0 ) {
						Task13.Sleep( 30 );
						this.add_log( "<span class='info'><B>Fibers:</B></span>" );

						foreach (dynamic _d in Lang13.Enumerate( fibers )) {
							fiber = _d;
							
							this.add_log( "" + fiber );
						}
						found_something = true;
					}

					if ( reagents != null && reagents.len != 0 ) {
						Task13.Sleep( 30 );
						this.add_log( "<span class='info'><B>Reagents:</B></span>" );

						foreach (dynamic _e in Lang13.Enumerate( reagents )) {
							R2 = _e;
							
							this.add_log( "Reagent: <font color='red'>" + R2 + "</font> Volume: <font color='red'>" + reagents[R2] + "</font>" );
						}
						found_something = true;
					}
					holder = null;

					if ( this.loc is Mob ) {
						holder = this.loc;
					}

					if ( !found_something ) {
						this.add_log( "<I># No forensic traces found #</I>", false );

						if ( holder != null ) {
							((dynamic)holder).WriteMsg( new Txt( "<span class='warning'>Unable to locate any fingerprints, materials, fibers, or blood on " ).the( target_name ).item().str( "!</span>" ).ToString() );
						}
					} else if ( holder != null ) {
						((dynamic)holder).WriteMsg( new Txt( "<span class='notice'>You finish scanning " ).the( target_name ).item().str( ".</span>" ).ToString() );
					}
					this.add_log( "---------------------------------------------------------", false );
					this.scanning = false;
					return;
					return;
				}));
			}
			return;
		}

		// Function from file: scanner.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			this.scan( target, user );
			return false;
		}

		// Function from file: scanner.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			return false;
		}

		// Function from file: scanner.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			Obj_Item_Weapon_Paper P = null;
			Ent_Static M = null;

			
			if ( this.log.len != 0 && !this.scanning ) {
				this.scanning = true;
				user.WriteMsg( "<span class='notice'>Printing report, please wait...</span>" );
				Task13.Schedule( 100, (Task13.Closure)(() => {
					P = new Obj_Item_Weapon_Paper( GlobalFuncs.get_turf( this ) );
					P.name = "paper- 'Scanner Report'";
					P.info = "<center><font size='6'><B>Scanner Report</B></font></center><HR><BR>";
					P.info += GlobalFuncs.jointext( this.log, "<BR>" );
					P.info += "<HR><B>Notes:</B><BR>";
					P.info_links = P.info;

					if ( this.loc is Mob ) {
						M = this.loc;
						((dynamic)M).put_in_hands( P );
						((dynamic)M).WriteMsg( "<span class='notice'>Report printed. Log cleared.<span>" );
					}
					this.log = new ByTable();
					this.scanning = false;
					return;
				}));
			} else {
				user.WriteMsg( "<span class='notice'>The scanner has no logs or is in use.</span>" );
			}
			return null;
		}

	}

}
// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Faxmachine : Obj_Machinery {

		public dynamic scan = null;
		public bool authenticated = false;
		public dynamic tofax = null;
		public double faxtime = 0;
		public dynamic cooldown_time = 900;
		public string department = "Unknown";
		public dynamic dpt = "Central Command";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_one_access = new ByTable(new object [] { 38, 19 });
			this.anchored = 1;
			this.idle_power_usage = 30;
			this.active_power_usage = 200;
			this.icon = "icons/obj/library.dmi";
			this.icon_state = "fax";
		}

		// Function from file: fax.dm
		public Obj_Machinery_Faxmachine ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable(new object [] { new Obj_Item_Weapon_Circuitboard_Fax(), new Obj_Item_Weapon_StockParts_Subspace_Ansible(), new Obj_Item_Weapon_StockParts_ScanningModule() });
			this.RefreshParts();
			GlobalVars.allfaxes.Add( this );

			if ( this.department == "Unknown" ) {
				this.department = "Fax #" + GlobalVars.allfaxes.len;
			}

			if ( !GlobalVars.alldepartments.Contains( "" + this.department ) ) {
				GlobalVars.alldepartments.Add( this.department );
			}
			return;
		}

		// Function from file: fax.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic idcard = null;

			
			if ( a is Obj_Item_Weapon_Paper ) {
				
				if ( !Lang13.Bool( this.tofax ) ) {
					
					if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
						this.tofax = a;
						GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You insert the paper into " ).the( this ).item().str( ".</span>" ).ToString() );
						Icon13.Flick( "faxsend", this );
						this.updateUsrDialog();
					}
				} else {
					GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>There is already something in " ).the( this ).item().str( ".</span>" ).ToString() );
				}
			} else if ( a is Obj_Item_Weapon_Card_Id ) {
				idcard = a;

				if ( !Lang13.Bool( this.scan ) ) {
					
					if ( Task13.User.drop_item( idcard, this ) ) {
						this.scan = idcard;
					}
				}
			} else if ( a is Obj_Item_Weapon_Wrench ) {
				GlobalFuncs.playsound( this.loc, "sound/items/Ratchet.ogg", 50, 1 );
				this.anchored = !Lang13.Bool( this.anchored );
				GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You " ).item( ( Lang13.Bool( this.anchored ) ? "wrench" : "unwrench" ) ).str( " " ).the( this ).item().str( ".</span>" ).ToString() );
			}
			return null;
		}

		// Function from file: fax.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic I = null;

			
			if ( Lang13.Bool( href_list["send"] ) ) {
				
				if ( Lang13.Bool( this.tofax ) ) {
					GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "(" + Task13.User + "/(" + Task13.User.ckey + ") sent a fax titled " + this.tofax + " to " + this.dpt + " - contents: " + this.tofax.info ) ) );

					if ( ( ( this.dpt == "Central Command" ?1:0) | ( this.dpt == "Nanotrasen HR" ?1:0) ) != 0 ) {
						
						if ( this.dpt == "Central Command" ) {
							GlobalFuncs.Centcomm_fax( this.tofax, this.tofax.name, Task13.User );
						}

						if ( this.dpt == "Nanotrasen HR" ) {
							
							if ( String13.FindIgnoreCase( this.tofax.stamps, "magnetic", 1, 0 ) != 0 ) {
								
								if ( String13.FindIgnoreCase( this.tofax.name, "Demotion", 1, 0 ) != 0 ) {
									new Obj_Item_DemoteChip( this.loc );
								}

								if ( String13.FindIgnoreCase( this.tofax.name, "Commendation", 1, 0 ) != 0 ) {
									new Obj_Item_Mounted_Poster( this.loc, -1 );
								}
							}
						}
					} else {
						GlobalFuncs.SendFax( this.tofax.info, this.tofax.name, Task13.User, this.dpt );
					}
					GlobalFuncs.to_chat( Task13.User, "Message transmitted successfully." );
					this.faxtime = Game13.timeofday + Convert.ToDouble( this.cooldown_time );
				}
			}

			if ( Lang13.Bool( href_list["remove"] ) ) {
				
				if ( Lang13.Bool( this.tofax ) ) {
					this.tofax.loc = Task13.User.loc;
					Task13.User.put_in_hands( this.tofax );
					GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>You take the paper out of " ).the( this ).item().str( ".</span>" ).ToString() );
					this.tofax = null;
				}
			}

			if ( Lang13.Bool( href_list["scan"] ) ) {
				
				if ( Lang13.Bool( this.scan ) ) {
					
					if ( Task13.User is Mob_Living_Carbon_Human ) {
						this.scan.loc = Task13.User.loc;

						if ( !Lang13.Bool( Task13.User.get_active_hand() ) ) {
							Task13.User.put_in_hands( this.scan );
						}
						this.scan = null;
					} else {
						this.scan.loc = this.loc;
						this.scan = null;
					}
				} else {
					I = Task13.User.get_active_hand();

					if ( I is Obj_Item_Weapon_Card_Id ) {
						
						if ( Task13.User.drop_item( I, this ) ) {
							this.scan = I;
						}
					}
				}
				this.authenticated = false;
			}

			if ( Lang13.Bool( href_list["dept"] ) ) {
				this.dpt = Interface13.Input( Task13.User, "Which department?", "Choose a department", "", GlobalVars.alldepartments, InputType.Null | InputType.Any );
			}

			if ( Lang13.Bool( href_list["auth"] ) ) {
				
				if ( !this.authenticated && Lang13.Bool( this.scan ) ) {
					
					if ( this.check_access( this.scan ) ) {
						this.authenticated = true;

						if ( Lang13.Bool( this.scan.access.Contains( GlobalVars.access_lawyer ) ) ) {
							GlobalVars.alldepartments.Add( "Nanotrasen HR" );
						}
					}
				}
			}

			if ( Lang13.Bool( href_list["logout"] ) ) {
				this.authenticated = false;

				if ( Lang13.Bool( this.scan.access.Contains( GlobalVars.access_lawyer ) ) ) {
					GlobalVars.alldepartments.Remove( "Nanotrasen HR" );
				}
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: fax.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string dat = null;
			string scan_name = null;

			((Mob)a).set_machine( this );
			dat = "Fax Machine<BR>";

			if ( Lang13.Bool( this.scan ) ) {
				scan_name = this.scan.name;
			} else {
				scan_name = "--------";
			}
			dat += new Txt( "Confirm Identity: <a href='byond://?src=" ).Ref( this ).str( ";scan=1'>" ).item( scan_name ).str( "</a><br>" ).ToString();

			if ( this.authenticated ) {
				dat += new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";logout=1'>{Log Out}</a>" ).ToString();
			} else {
				dat += new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";auth=1'>{Log In}</a>" ).ToString();
			}
			dat += "<hr>";

			if ( this.authenticated ) {
				dat += "<b>Logged in to:</b> Central Command Quantum Entanglement Network<br><br>";

				if ( Lang13.Bool( this.tofax ) ) {
					dat += new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";remove=1'>Remove Paper</a><br><br>" ).ToString();

					if ( this.faxtime > Game13.timeofday ) {
						dat += new Txt( "<b>Transmitter arrays realigning. Please stand by for " ).item( ( this.faxtime - Game13.timeofday ) / 10 ).str( " second" ).s().str( ".</b><br>" ).ToString();
					} else {
						dat += new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";send=1'>Send</a><br>" ).ToString();
						dat += "<b>Currently sending:</b> " + this.tofax.name + "<br>";

						if ( this.dpt == null ) {
							this.dpt = "Central Command";
						}
						dat += new Txt( "<b>Sending to:</b> <a href='byond://?src=" ).Ref( this ).str( ";dept=1'>" ).item( this.dpt ).str( "</a><br>" ).ToString();
					}
				} else if ( this.faxtime > Game13.timeofday ) {
					dat += "Please insert paper to send via secure connection.<br><br>";
					dat += new Txt( "<b>Transmitter arrays realigning. Please stand by for " ).item( ( this.faxtime - Game13.timeofday ) / 10 ).str( " second" ).s().str( ".</b><br>" ).ToString();
				} else {
					dat += "Please insert paper to send via secure connection.<br><br>";
				}
			} else {
				dat += "ÿauthentication is required to use this device.<br><br>";

				if ( Lang13.Bool( this.tofax ) ) {
					dat += new Txt( "<a href ='byond://?src=" ).Ref( this ).str( ";remove=1'>Remove Paper</a><br>" ).ToString();
				}
			}
			Interface13.Browse( a, dat, "window=copier" );
			GlobalFuncs.onclose( a, "copier" );
			return null;
		}

		// Function from file: fax.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: fax.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return this.attack_hand( user );
		}

		// Function from file: fax.dm
		public override dynamic attack_ghost( Mob_Dead_Observer user = null ) {
			GlobalFuncs.to_chat( Task13.User, "<span class='warning'>Nope.</span>" );
			return 0;
		}

		// Function from file: fax.dm
		public override dynamic RefreshParts(  ) {
			int scancount = 0;
			Obj_Item_Weapon_StockParts SP = null;

			scancount = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts) )) {
				SP = _a;
				

				if ( SP is Obj_Item_Weapon_StockParts_ScanningModule ) {
					scancount += SP.rating - 1;
				}
			}
			this.cooldown_time = Lang13.Initial( this, "cooldown_time" ) - scancount * 300;
			return null;
		}

	}

}
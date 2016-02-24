// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Navbeacon : Obj_Machinery {

		public bool open = false;
		public bool locked = true;
		public int freq = 1445;
		public string location = "";
		public ByTable codes = null;
		public string codes_txt = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.level = 1;
			this.anchored = 1;
			this.req_access = new ByTable(new object [] { 10, 29 });
			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "navbeacon0-f";
			this.layer = 2.5;
		}

		// Function from file: navbeacon.dm
		public Obj_Machinery_Navbeacon ( dynamic loc = null ) : base( (object)(loc) ) {
			Ent_Static T = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.set_codes();
			T = this.loc;
			this.hide( Lang13.Bool( ((dynamic)T).intact ) );

			if ( Lang13.Bool( this.codes["patrol"] ) ) {
				GlobalVars.navbeacons.Add( this );
			}

			if ( Lang13.Bool( this.codes["delivery"] ) ) {
				GlobalVars.deliverybeacons.Add( this );
				GlobalVars.deliverybeacontags.Add( this.location );
			}
			return;
		}

		// Function from file: navbeacon.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			string newloc = null;
			dynamic codekey = null;
			string newkey = null;
			dynamic codeval = null;
			string newval = null;
			dynamic codekey2 = null;
			string newkey2 = null;
			string newval2 = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}

			if ( this.open && !this.locked ) {
				Task13.User.set_machine( this );

				if ( Lang13.Bool( href_list["locedit"] ) ) {
					newloc = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Enter New Location", "Navigation Beacon", this.location, null, null, InputType.Str | InputType.Null ) ), 1, 1024 );

					if ( Lang13.Bool( newloc ) ) {
						this.location = newloc;
						this.updateDialog();
					}
				} else if ( Lang13.Bool( href_list["edit"] ) ) {
					codekey = href_list["code"];
					newkey = GlobalFuncs.stripped_input( Task13.User, "Enter Transponder Code Key", "Navigation Beacon", codekey );

					if ( !Lang13.Bool( newkey ) ) {
						return null;
					}
					codeval = this.codes[codekey];
					newval = GlobalFuncs.stripped_input( Task13.User, "Enter Transponder Code Value", "Navigation Beacon", codeval );

					if ( !Lang13.Bool( newval ) ) {
						newval = codekey;
						return null;
					}
					this.codes.Remove( codekey );
					this.codes[newkey] = newval;
					this.updateDialog();
				} else if ( Lang13.Bool( href_list["delete"] ) ) {
					codekey2 = href_list["code"];
					this.codes.Remove( codekey2 );
					this.updateDialog();
				} else if ( Lang13.Bool( href_list["add"] ) ) {
					newkey2 = GlobalFuncs.stripped_input( Task13.User, "Enter New Transponder Code Key", "Navigation Beacon" );

					if ( !Lang13.Bool( newkey2 ) ) {
						return null;
					}
					newval2 = GlobalFuncs.stripped_input( Task13.User, "Enter New Transponder Code Value", "Navigation Beacon" );

					if ( !Lang13.Bool( newval2 ) ) {
						newval2 = "1";
						return null;
					}

					if ( !( this.codes != null ) ) {
						this.codes = new ByTable();
					}
					this.codes[newkey2] = newval2;
					this.updateDialog();
				}
			}
			return null;
		}

		// Function from file: navbeacon.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			flag1 = flag1 ?? false;

			Ent_Static T = null;
			string t = null;
			dynamic key = null;
			dynamic key2 = null;
			Browser popup = null;

			T = this.loc;

			if ( Lang13.Bool( ((dynamic)T).intact ) ) {
				return null;
			}

			if ( !this.open && !( flag1 == true ) ) {
				user.WriteMsg( "<span class='warning'>The beacon's control cover is closed!</span>" );
				return null;
			}

			if ( this.locked && !( flag1 == true ) ) {
				t = "<TT><B>Navigation Beacon</B><HR><BR>\n<i>(swipe card to unlock controls)</i><BR>\nLocation: " + ( Lang13.Bool( this.location ) ? this.location : "(none)" ) + "</A><BR>\nTransponder Codes:<UL>";

				foreach (dynamic _a in Lang13.Enumerate( this.codes )) {
					key = _a;
					
					t += "<LI>" + key + " ... " + this.codes[key];
				}
				t += "<UL></TT>";
			} else {
				t = new Txt( @"<TT><B>Navigation Beacon</B><HR><BR>
<i>(swipe card to lock controls)</i><BR>

<HR>
Location: <A href='byond://?src=" ).Ref( this ).str( ";locedit=1'>" ).item( ( Lang13.Bool( this.location ) ? this.location : "None" ) ).str( "</A><BR>\nTransponder Codes:<UL>" ).ToString();

				foreach (dynamic _b in Lang13.Enumerate( this.codes )) {
					key2 = _b;
					
					t += "<LI>" + key2 + " ... " + this.codes[key2];
					t += new Txt( "	<A href='byond://?src=" ).Ref( this ).str( ";edit=1;code=" ).item( key2 ).str( "'>Edit</A>" ).ToString();
					t += new Txt( "	<A href='byond://?src=" ).Ref( this ).str( ";delete=1;code=" ).item( key2 ).str( "'>Delete</A><BR>" ).ToString();
				}
				t += new Txt( "	<A href='byond://?src=" ).Ref( this ).str( ";add=1;'>Add New</A><BR>" ).ToString();
				t += "<UL></TT>";
			}
			popup = new Browser( user, "navbeacon", "Navigation Beacon", 300, 400 );
			popup.set_content( t );
			popup.open();
			return null;
		}

		// Function from file: navbeacon.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			this.interact( a, false );
			return null;
		}

		// Function from file: navbeacon.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return null;
		}

		// Function from file: navbeacon.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.interact( user, true );
			return null;
		}

		// Function from file: navbeacon.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			Ent_Static T = null;

			T = this.loc;

			if ( Lang13.Bool( ((dynamic)T).intact ) ) {
				return null;
			}

			if ( A is Obj_Item_Weapon_Screwdriver ) {
				this.open = !this.open;
				((Ent_Static)user).visible_message( "" + user + " " + ( this.open ? "opens" : "closes" ) + " the beacon's cover.", "<span class='notice'>You " + ( this.open ? "open" : "close" ) + " the beacon's cover.</span>" );
				this.updateicon();
			} else if ( A is Obj_Item_Weapon_Card_Id || A is Obj_Item_Device_Pda ) {
				
				if ( this.open ) {
					
					if ( this.allowed( user ) ) {
						this.locked = !this.locked;
						user.WriteMsg( "<span class='notice'>Controls are now " + ( this.locked ? "locked" : "unlocked" ) + ".</span>" );
					} else {
						user.WriteMsg( "<span class='danger'>Access denied.</span>" );
					}
					this.updateDialog();
				} else {
					user.WriteMsg( "<span class='warning'>You must open the cover first!</span>" );
				}
			}
			return null;
		}

		// Function from file: navbeacon.dm
		public override void hide( bool h = false ) {
			this.invisibility = ( h ? 101 : 0 );
			this.updateicon();
			return;
		}

		// Function from file: navbeacon.dm
		public void updateicon(  ) {
			string state = null;

			state = "navbeacon" + this.open;

			if ( this.invisibility != 0 ) {
				this.icon_state = "" + state + "-f";
			} else {
				this.icon_state = "" + state;
			}
			return;
		}

		// Function from file: navbeacon.dm
		public void set_codes(  ) {
			ByTable entries = null;
			dynamic e = null;
			int index = 0;
			string key = null;
			string val = null;

			
			if ( !Lang13.Bool( this.codes_txt ) ) {
				return;
			}
			this.codes = new ByTable();
			entries = GlobalFuncs.splittext( this.codes_txt, ";" );

			foreach (dynamic _a in Lang13.Enumerate( entries )) {
				e = _a;
				
				index = String13.FindIgnoreCase( e, "=", 1, 0 );

				if ( index != 0 ) {
					key = String13.SubStr( e, 1, index );
					val = String13.SubStr( e, index + 1, 0 );
					this.codes[key] = val;
				} else {
					this.codes[e] = "1";
				}
			}
			return;
		}

		// Function from file: navbeacon.dm
		public override dynamic Destroy(  ) {
			GlobalVars.navbeacons.And( this );
			GlobalVars.deliverybeacons.And( this );
			return base.Destroy();
		}

	}

}
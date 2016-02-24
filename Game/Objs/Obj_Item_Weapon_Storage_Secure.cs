// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Secure : Obj_Item_Weapon_Storage {

		public string icon_locking = "secureb";
		public string icon_sparking = "securespark";
		public string icon_opened = "secure0";
		public bool locked = true;
		public string code = "";
		public string l_code = null;
		public bool l_set = false;
		public bool l_setshort = false;
		public bool l_hacking = false;
		public bool emagged = false;
		public bool open = false;

		public Obj_Item_Weapon_Storage_Secure ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: secure.dm
		public override bool can_be_inserted( dynamic W = null, bool? stop_messages = null, dynamic user = null ) {
			stop_messages = stop_messages ?? false;

			
			if ( this.locked ) {
				return false;
			}
			return base.can_be_inserted( (object)(W), stop_messages, (object)(user) );
		}

		// Function from file: secure.dm
		public override bool storage_contents_dump_act( Obj_Item_Weapon_Storage src_object = null, Mob user = null ) {
			
			if ( this.locked ) {
				user.WriteMsg( "<span class='warning'>It's locked!</span>" );
				return false;
			}
			return base.storage_contents_dump_act( src_object, user );
		}

		// Function from file: secure.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			dynamic M = null;

			base.Topic( href, href_list, (object)(hsrc) );

			if ( Task13.User.stat != 0 || Task13.User.restrained() || Map13.GetDistance( this, Task13.User ) > 1 ) {
				return null;
			}

			if ( Lang13.Bool( href_list["type"] ) ) {
				
				if ( href_list["type"] == "E" ) {
					
					if ( !this.l_set && Lang13.Length( this.code ) == 5 && !this.l_setshort && this.code != "ERROR" ) {
						this.l_code = this.code;
						this.l_set = true;
					} else if ( this.code == this.l_code && !this.emagged && this.l_set ) {
						this.locked = false;
						this.overlays = null;
						this.overlays.Add( new Image( "icons/obj/storage.dmi", this.icon_opened ) );
						this.code = null;
					} else {
						this.code = "ERROR";
					}
				} else if ( href_list["type"] == "R" && !this.emagged && !this.l_setshort ) {
					this.locked = true;
					this.overlays = null;
					this.code = null;
					this.close( Task13.User );
				} else {
					this.code += "" + href_list["type"];

					if ( Lang13.Length( this.code ) > 5 ) {
						this.code = "ERROR";
					}
				}
				this.add_fingerprint( Task13.User );

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( this.loc, 1 ) )) {
					M = _a;
					

					if ( Lang13.Bool( M.client ) && M.machine == this ) {
						this.attack_self( M );
					}
					return null;
				}
			}
			return null;
		}

		// Function from file: secure.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			string dat = null;
			string message = null;

			((Mob)user).set_machine( this );
			dat = "<TT><B>" + this + "</B><BR>\n\nLock Status: " + ( this.locked ? "LOCKED" : "UNLOCKED" );
			message = "Code";

			if ( !this.l_set && !this.emagged && !this.l_setshort ) {
				dat += "<p>\n<b>5-DIGIT PASSCODE NOT SET.<br>ENTER NEW PASSCODE.</b>";
			}

			if ( this.emagged ) {
				dat += "<p>\n<font color=red><b>LOCKING SYSTEM ERROR - 1701</b></font>";
			}

			if ( this.l_setshort ) {
				dat += "<p>\n<font color=red><b>ALERT: MEMORY SYSTEM ERROR - 6040 201</b></font>";
			}
			message = "" + this.code;

			if ( !this.locked ) {
				message = "*****";
			}
			dat += new Txt( "<HR>\n>" ).item( message ).str( "<BR>\n<A href='?src=" ).Ref( this ).str( ";type=1'>1</A>-<A href='?src=" ).Ref( this ).str( ";type=2'>2</A>-<A href='?src=" ).Ref( this ).str( ";type=3'>3</A><BR>\n<A href='?src=" ).Ref( this ).str( ";type=4'>4</A>-<A href='?src=" ).Ref( this ).str( ";type=5'>5</A>-<A href='?src=" ).Ref( this ).str( ";type=6'>6</A><BR>\n<A href='?src=" ).Ref( this ).str( ";type=7'>7</A>-<A href='?src=" ).Ref( this ).str( ";type=8'>8</A>-<A href='?src=" ).Ref( this ).str( ";type=9'>9</A><BR>\n<A href='?src=" ).Ref( this ).str( ";type=R'>R</A>-<A href='?src=" ).Ref( this ).str( ";type=0'>0</A>-<A href='?src=" ).Ref( this ).str( ";type=E'>E</A><BR>\n</TT>" ).ToString();
			Interface13.Browse( user, dat, "window=caselock;size=300x280" );
			return null;
		}

		// Function from file: secure.dm
		public override dynamic MouseDrop( dynamic over = null, dynamic src_location = null, dynamic over_location = null, string src_control = null, dynamic over_control = null, string _params = null ) {
			
			if ( this.locked ) {
				this.add_fingerprint( Task13.User );
				Task13.User.WriteMsg( "<span class='warning'>It's locked!</span>" );
				return 0;
			}
			base.MouseDrop( (object)(over), (object)(src_location), (object)(over_location), src_control, (object)(over_control), _params );
			return null;
		}

		// Function from file: secure.dm
		public override bool emag_act( dynamic user = null ) {
			
			if ( this.locked ) {
				
				if ( !this.emagged ) {
					this.emagged = true;
					this.overlays.Add( new Image( "icons/obj/storage.dmi", this.icon_sparking ) );
					Task13.Sleep( 6 );
					this.overlays = null;
					this.overlays.Add( new Image( "icons/obj/storage.dmi", this.icon_locking ) );
					this.locked = false;
					user.WriteMsg( "<span class='notice'>You short out the lock on " + this + ".</span>" );
				}
			}
			return false;
		}

		// Function from file: secure.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( this.locked ) {
				
				if ( A is Obj_Item_Weapon_Screwdriver ) {
					
					if ( GlobalFuncs.do_after( user, 20 / A.toolspeed, null, this ) ) {
						this.open = !this.open;
						user.show_message( "<span class='notice'>You " + ( this.open ? "open" : "close" ) + " the service panel.</span>", 1 );
					}
					return null;
				}

				if ( A is Obj_Item_Device_Multitool && this.open && !this.l_hacking ) {
					user.show_message( "<span class='danger'>Now attempting to reset internal memory, please hold.</span>", 1 );
					this.l_hacking = true;

					if ( GlobalFuncs.do_after( Task13.User, 100 / A.toolspeed, null, this ) ) {
						
						if ( Rand13.PercentChance( 40 ) ) {
							this.l_setshort = true;
							this.l_set = false;
							user.show_message( "<span class='danger'>Internal memory reset.  Please give it a few seconds to reinitialize.</span>", 1 );
							Task13.Sleep( 80 );
							this.l_setshort = false;
							this.l_hacking = false;
						} else {
							user.show_message( "<span class='danger'>Unable to reset internal memory.</span>", 1 );
							this.l_hacking = false;
						}
					} else {
						this.l_hacking = false;
					}
					return null;
				}
				return null;
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: secure.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( "The service panel is " + ( this.open ? "open" : "closed" ) + "." );
			return 0;
		}

	}

}
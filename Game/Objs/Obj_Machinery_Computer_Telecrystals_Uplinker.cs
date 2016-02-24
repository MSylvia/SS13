// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Telecrystals_Uplinker : Obj_Machinery_Computer_Telecrystals {

		public dynamic uplinkholder = null;
		public Obj_Machinery_Computer_Telecrystals_Boss linkedboss = null;

		// Function from file: telecrystalconsoles.dm
		public Obj_Machinery_Computer_Telecrystals_Uplinker ( dynamic location = null, dynamic C = null ) : base( (object)(location), (object)(C) ) {
			dynamic ID = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( GlobalVars.possible_uplinker_IDs.len != 0 ) {
				ID = Rand13.PickFromTable( GlobalVars.possible_uplinker_IDs );
				GlobalVars.possible_uplinker_IDs.Remove( ID );
				this.name = "" + this.name + " " + ID;
			} else {
				this.name = "" + this.name + " " + Rand13.Int( 1, 999 );
			}
			return;
		}

		// Function from file: telecrystalconsoles.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}

			if ( Lang13.Bool( href_list["donate1"] ) ) {
				this.donateTC( 1 );
			}

			if ( Lang13.Bool( href_list["donate5"] ) ) {
				this.donateTC( 5 );
			}

			if ( Lang13.Bool( href_list["eject"] ) ) {
				this.ejectuplink();
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: telecrystalconsoles.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			string dat = null;
			Browser popup = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), b, c ) ) ) {
				return null;
			}
			this.add_fingerprint( a );
			((Mob)a).set_machine( this );
			dat = "";

			if ( this.linkedboss != null ) {
				dat += "" + this.linkedboss + " has " + this.linkedboss.storedcrystals + " telecrystals available for distribution. <BR><BR>";
			} else {
				dat += "No linked management consoles detected. Scan for uplink stations using the management console.<BR><BR>";
			}

			if ( Lang13.Bool( this.uplinkholder ) ) {
				dat += "" + this.uplinkholder.hidden_uplink.telecrystals + " telecrystals remain in this uplink.<BR>";

				if ( this.linkedboss != null ) {
					dat += new Txt( "Donate TC: <a href='byond://?src=" ).Ref( this ).str( ";donate1=1'>1</a> | <a href='byond://?src=" ).Ref( this ).str( ";donate5=1'>5</a>" ).ToString();
				}
				dat += new Txt( "<br><a href='byond://?src=" ).Ref( this ).str( ";eject=1'>Eject Uplink</a>" ).ToString();
			}
			popup = new Browser( a, "computer", "Telecrystal Upload/Receive Station", 700, 500 );
			popup.set_content( dat );
			popup.set_title_image( ((Mob)a).browse_rsc_icon( this.icon, this.icon_state ) );
			popup.open();
			return null;
		}

		// Function from file: telecrystalconsoles.dm
		public void giveTC( double amt = 0, bool? addLog = null ) {
			addLog = addLog ?? true;

			
			if ( Lang13.Bool( this.uplinkholder ) && this.linkedboss != null ) {
				
				if ( amt <= this.linkedboss.storedcrystals ) {
					this.uplinkholder.hidden_uplink.telecrystals += amt;
					this.linkedboss.storedcrystals -= amt;

					if ( addLog == true ) {
						this.linkedboss.logTransfer( "" + this + " received " + amt + " telecrystals from " + this.linkedboss + "." );
					}
				}
			}
			return;
		}

		// Function from file: telecrystalconsoles.dm
		public void donateTC( int amt = 0, bool? addLog = null ) {
			addLog = addLog ?? true;

			
			if ( Lang13.Bool( this.uplinkholder ) && this.linkedboss != null ) {
				
				if ( amt <= Convert.ToDouble( this.uplinkholder.hidden_uplink.telecrystals ) ) {
					this.uplinkholder.hidden_uplink.telecrystals -= amt;
					this.linkedboss.storedcrystals += amt;

					if ( addLog == true ) {
						this.linkedboss.logTransfer( "" + this + " donated " + amt + " telecrystals to " + this.linkedboss + "." );
					}
				}
			}
			return;
		}

		// Function from file: telecrystalconsoles.dm
		public void ejectuplink(  ) {
			
			if ( Lang13.Bool( this.uplinkholder ) ) {
				this.uplinkholder.loc = GlobalFuncs.get_turf( this.loc );
				this.uplinkholder = null;
				this.update_icon();
			}
			return;
		}

		// Function from file: telecrystalconsoles.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );

			if ( Lang13.Bool( this.uplinkholder ) ) {
				this.overlays.Add( "" + Lang13.Initial( this, "icon_state" ) + "-closed" );
			}
			return false;
		}

		// Function from file: telecrystalconsoles.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic I = null;

			
			if ( A is Obj_Item ) {
				
				if ( Lang13.Bool( this.uplinkholder ) ) {
					user.WriteMsg( "<span class='notice'>The " + this + " already has an uplink in it.</span>" );
					return null;
				}

				if ( A.hidden_uplink != null ) {
					I = ((Mob)user).get_active_hand();

					if ( !Lang13.Bool( user.drop_item() ) ) {
						return null;
					}
					this.uplinkholder = I;
					I.loc = this;
					((Ent_Static)I).add_fingerprint( user );
					this.update_icon();
					this.updateUsrDialog();
				} else {
					user.WriteMsg( "<span class='notice'>The " + A + " doesn't appear to be an uplink...</span>" );
				}
			}
			return null;
		}

	}

}
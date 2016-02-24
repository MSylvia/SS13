// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Powersink : Obj_Item_Device {

		public int drain_rate = 1600000;
		public double power_drained = 0;
		public double max_power = 10000000000;
		public int mode = 0;
		public bool admins_warned = false;
		public bool DISCONNECTED = false;
		public bool CLAMPED_OFF = true;
		public int OPERATING = 2;
		public dynamic attached = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "electronic";
			this.w_class = 4;
			this.flags = 64;
			this.throwforce = 5;
			this.throw_speed = 1;
			this.throw_range = 2;
			this.materials = new ByTable().Set( "$metal", 750 );
			this.origin_tech = "powerstorage=3;syndicate=5";
			this.icon_state = "powersink0";
		}

		public Obj_Item_Device_Powersink ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: powersink.dm
		public override int? process( dynamic seconds = null ) {
			Powernet PN = null;
			int drained = 0;
			Obj_Machinery_Power_Terminal T = null;
			Obj_Machinery_Power A = null;

			
			if ( !Lang13.Bool( this.attached ) ) {
				this.set_mode( GlobalVars.DISCONNECTED );
				return null;
			}
			PN = this.attached.powernet;

			if ( PN != null ) {
				this.SetLuminosity( 5 );
				drained = Num13.MinInt( this.drain_rate, ((int)( PN.avail )) );
				PN.load += drained;
				this.power_drained += drained;

				if ( drained < this.drain_rate ) {
					
					foreach (dynamic _a in Lang13.Enumerate( PN.nodes, typeof(Obj_Machinery_Power_Terminal) )) {
						T = _a;
						

						if ( T.master is Obj_Machinery_Power_Apc ) {
							A = T.master;

							if ( Lang13.Bool( ((dynamic)A).operating ) && Lang13.Bool( ((dynamic)A).cell ) ) {
								((dynamic)A).cell.charge = Num13.MaxInt( 0, Convert.ToInt32( ((dynamic)A).cell.charge - 50 ) );
								this.power_drained += 50;

								if ( Convert.ToInt32( ((dynamic)A).charging ) == 2 ) {
									((dynamic)A).charging = 1;
								}
							}
						}
					}
				}
			}

			if ( this.power_drained > this.max_power * 0.98 ) {
				
				if ( !this.admins_warned ) {
					this.admins_warned = true;
					GlobalFuncs.message_admins( "Power sink at (" + this.x + "," + this.y + "," + this.z + " - <A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" + this.x + ";Y=" + this.y + ";Z=" + this.z + "'>JMP</a>) is 95% full. Explosion imminent." );
				}
				GlobalFuncs.playsound( this, "sound/effects/screech.ogg", 100, 1, 1 );
			}

			if ( this.power_drained >= this.max_power ) {
				GlobalVars.SSobj.processing.Remove( this );
				GlobalFuncs.explosion( this.loc, 4, 8, 16, 32 );
				GlobalFuncs.qdel( this );
			}
			return null;
		}

		// Function from file: powersink.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			switch ((int)( this.mode )) {
				case 0:
					base.attack_hand( (object)(a), b, c );
					break;
				case 1:
					((Ent_Static)a).visible_message( new Txt().item( a ).str( " activates " ).the( this ).item().str( "!" ).ToString(), new Txt( "<span class='notice'>You activate " ).the( this ).item().str( ".</span>" ).ToString(), "<span class='italics'>You hear a click.</span>" );
					GlobalFuncs.message_admins( new Txt( "Power sink activated by " ).item( GlobalFuncs.key_name_admin( a ) ).str( "(<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( a ).str( "'>?</A>) (<A HREF='?_src_=holder;adminplayerobservefollow=" ).Ref( a ).str( "'>FLW</A>) at (" ).item( this.x ).str( "," ).item( this.y ).str( "," ).item( this.z ).str( " - <A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" ).item( this.x ).str( ";Y=" ).item( this.y ).str( ";Z=" ).item( this.z ).str( "'>JMP</a>)" ).ToString() );
					GlobalFuncs.log_game( "Power sink activated by " + GlobalFuncs.key_name( a ) + " at (" + this.x + "," + this.y + "," + this.z + ")" );
					this.set_mode( GlobalVars.OPERATING );
					break;
				case 2:
					((Ent_Static)a).visible_message( new Txt().item( a ).str( " deactivates " ).the( this ).item().str( "!" ).ToString(), new Txt( "<span class='notice'>You deactivate " ).the( this ).item().str( ".</span>" ).ToString(), "<span class='italics'>You hear a click.</span>" );
					this.set_mode( GlobalVars.CLAMPED_OFF );
					break;
			}
			return null;
		}

		// Function from file: powersink.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return null;
		}

		// Function from file: powersink.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return null;
		}

		// Function from file: powersink.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			Ent_Static T = null;

			
			if ( A is Obj_Item_Weapon_Screwdriver ) {
				
				if ( this.mode == GlobalVars.DISCONNECTED ) {
					T = this.loc;

					if ( T is Tile && !Lang13.Bool( ((dynamic)T).intact ) ) {
						this.attached = Lang13.FindIn( typeof(Obj_Structure_Cable), T );

						if ( !Lang13.Bool( this.attached ) ) {
							user.WriteMsg( "<span class='warning'>This device must be placed over an exposed, powered cable node!</span>" );
						} else {
							this.set_mode( GlobalVars.CLAMPED_OFF );
							((Ent_Static)user).visible_message( new Txt().item( user ).str( " attaches " ).the( this ).item().str( " to the cable." ).ToString(), new Txt( "<span class='notice'>You attach " ).the( this ).item().str( " to the cable.</span>" ).ToString(), "<span class='italics'>You hear some wires being connected to something.</span>" );
						}
					} else {
						user.WriteMsg( "<span class='warning'>This device must be placed over an exposed, powered cable node!</span>" );
					}
				} else {
					this.set_mode( GlobalVars.DISCONNECTED );
					((Ent_Static)user).visible_message( new Txt().item( user ).str( " detaches " ).the( this ).item().str( " from the cable." ).ToString(), new Txt( "<span class='notice'>You detach " ).the( this ).item().str( " from the cable.</span>" ).ToString(), "<span class='italics'>You hear some wires being disconnected from something.</span>" );
				}
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: powersink.dm
		public void set_mode( int value = 0 ) {
			
			if ( value == this.mode ) {
				return;
			}

			switch ((int)( value )) {
				case 0:
					this.attached = null;

					if ( this.mode == GlobalVars.OPERATING ) {
						GlobalVars.SSobj.processing.Remove( this );
					}
					this.anchored = 0;
					break;
				case 1:
					
					if ( !Lang13.Bool( this.attached ) ) {
						return;
					}

					if ( this.mode == GlobalVars.OPERATING ) {
						GlobalVars.SSobj.processing.Remove( this );
					}
					this.anchored = 1;
					break;
				case 2:
					
					if ( !Lang13.Bool( this.attached ) ) {
						return;
					}
					GlobalVars.SSobj.processing.Or( this );
					this.anchored = 1;
					break;
			}
			this.mode = value;
			this.update_icon();
			this.SetLuminosity( 0 );
			return;
		}

		// Function from file: powersink.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.icon_state = "powersink" + ( this.mode == GlobalVars.OPERATING );
			return false;
		}

	}

}
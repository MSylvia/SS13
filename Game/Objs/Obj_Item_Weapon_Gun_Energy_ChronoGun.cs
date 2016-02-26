// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_ChronoGun : Obj_Item_Weapon_Gun_Energy {

		public dynamic TED = null;
		public Obj_Effect_ChronoField field = null;
		public dynamic startpos = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "chronogun";
			this.flags = 2;
			this.ammo_type = new ByTable(new object [] { typeof(Obj_Item_AmmoCasing_Energy_ChronoBeam) });
			this.can_charge = false;
			this.fire_delay = 50;
			this.icon = "icons/obj/chronos.dmi";
			this.icon_state = "chronogun";
		}

		// Function from file: chrono_eraser.dm
		public Obj_Item_Weapon_Gun_Energy_ChronoGun ( dynamic T = null ) : base( (object)(T) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( T is Obj_Item_Weapon_ChronoEraser ) {
				this.TED = T;
			} else {
				this.TED = new Obj_Item_Weapon_ChronoEraser( this.loc );
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: chrono_eraser.dm
		public void pass_mind( dynamic M = null ) {
			
			if ( Lang13.Bool( this.TED ) ) {
				this.TED.pass_mind( M );
			}
			return;
		}

		// Function from file: chrono_eraser.dm
		public bool field_check( Obj_Effect_ChronoField F = null ) {
			dynamic currentpos = null;
			Ent_Static user = null;

			
			if ( F != null ) {
				
				if ( this.field == F ) {
					currentpos = GlobalFuncs.get_turf( this );
					user = this.loc;

					if ( currentpos == this.startpos && Map13.FetchInView( currentpos, 3 ).Contains( this.field ) && !Lang13.Bool( ((dynamic)user).lying ) && Lang13.Bool( ((dynamic)user).stat ) == false ) {
						return true;
					}
				}
				this.field_disconnect( F );
				return false;
			}
			return false;
		}

		// Function from file: chrono_eraser.dm
		public void field_disconnect( Obj_Effect_ChronoField F = null ) {
			Ent_Static user = null;

			
			if ( F != null && this.field == F ) {
				user = this.loc;

				if ( F.gun == this ) {
					F.gun = null;
				}

				if ( user is Mob_Living && F.captured != null ) {
					((dynamic)user).WriteMsg( "<span class='alert'>Disconnected from target: <b>" + F.captured + "</b></span>" );
				}
			}
			this.field = null;
			this.startpos = null;
			return;
		}

		// Function from file: chrono_eraser.dm
		public void field_connect( Obj_Effect_ChronoField F = null ) {
			Ent_Static user = null;

			user = this.loc;

			if ( F.gun != null ) {
				
				if ( user is Mob_Living && F.captured != null ) {
					((dynamic)user).WriteMsg( "<span class='alert'><b>FAIL: <i>" + F.captured + "</i> already has an existing connection.</b></span>" );
				}
				this.field_disconnect( F );
			} else {
				this.startpos = GlobalFuncs.get_turf( this );
				this.field = F;
				F.gun = this;

				if ( user is Mob_Living && F.captured != null ) {
					((dynamic)user).WriteMsg( "<span class='notice'>Connection established with target: <b>" + F.captured + "</b></span>" );
				}
			}
			return;
		}

		// Function from file: chrono_eraser.dm
		public override dynamic Destroy(  ) {
			
			if ( Lang13.Bool( this.TED ) ) {
				this.TED.PA = null;
				this.TED = null;
			}

			if ( this.field != null ) {
				this.field_disconnect( this.field );
			}
			return base.Destroy();
		}

		// Function from file: chrono_eraser.dm
		public override bool process_fire( dynamic target = null, dynamic user = null, bool? message = null, string _params = null, string zone_override = null ) {
			
			if ( this.field != null ) {
				this.field_disconnect( this.field );
			}
			base.process_fire( (object)(target), (object)(user), message, _params, zone_override );
			return false;
		}

		// Function from file: chrono_eraser.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			return false;
		}

		// Function from file: chrono_eraser.dm
		public override bool dropped( dynamic user = null ) {
			GlobalFuncs.qdel( this );
			return false;
		}

	}

}
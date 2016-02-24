// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_PortaTurretCover : Obj_Machinery {

		public Obj_Machinery_PortaTurret Parent_Turret = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/turrets.dmi";
			this.icon_state = "turretCover";
			this.layer = 3.5;
		}

		public Obj_Machinery_PortaTurretCover ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: portable_turret.dm
		public override bool emag_act( dynamic user = null ) {
			
			if ( !Lang13.Bool( this.Parent_Turret.emagged ) ) {
				user.WriteMsg( "<span class='notice'>You short out " + this.Parent_Turret + "'s threat assessment circuits.</span>" );
				this.visible_message( "" + this.Parent_Turret + " hums oddly..." );
				this.Parent_Turret.emagged = 1;
				this.Parent_Turret.on = false;
				Task13.Sleep( 40 );
				this.Parent_Turret.on = true;
			}
			return false;
		}

		// Function from file: portable_turret.dm
		public override bool can_be_overridden(  ) {
			bool _default = false;

			_default = false;
			return _default;
		}

		// Function from file: portable_turret.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic M = null;

			
			if ( A is Obj_Item_Weapon_Wrench && !this.Parent_Turret.on ) {
				
				if ( this.Parent_Turret.raised ) {
					return null;
				}

				if ( !Lang13.Bool( this.Parent_Turret.anchored ) ) {
					this.Parent_Turret.anchored = 1;
					this.Parent_Turret.invisibility = 60;
					this.Parent_Turret.icon_state = "grey_target_prism";
					user.WriteMsg( "<span class='notice'>You secure the exterior bolts on the turret.</span>" );
				} else {
					this.Parent_Turret.anchored = 0;
					user.WriteMsg( "<span class='notice'>You unsecure the exterior bolts on the turret.</span>" );
					this.Parent_Turret.icon_state = "turretCover";
					this.Parent_Turret.invisibility = 0;
					GlobalFuncs.qdel( this );
				}
			} else if ( A is Obj_Item_Weapon_Card_Id || A is Obj_Item_Device_Pda ) {
				
				if ( this.Parent_Turret.allowed( user ) ) {
					this.Parent_Turret.locked = !this.Parent_Turret.locked;
					user.WriteMsg( "<span class='notice'>Controls are now " + ( this.Parent_Turret.locked ? "locked" : "unlocked" ) + ".</span>" );
					this.updateUsrDialog();
				} else {
					user.WriteMsg( "<span class='notice'>Access denied.</span>" );
				}
			} else if ( A is Obj_Item_Device_Multitool && !this.Parent_Turret.locked ) {
				M = A;
				M.buffer = this.Parent_Turret;
				user.WriteMsg( "<span class='notice'>You add " + this.Parent_Turret + " to multitool buffer.</span>" );
			} else {
				((Mob)user).changeNext_move( 8 );
				this.Parent_Turret.health -= Convert.ToDouble( A.force * 0.5 );

				if ( this.Parent_Turret.health <= 0 ) {
					this.Parent_Turret.die();
				}

				if ( Convert.ToDouble( A.force * 0.5 ) > 2 ) {
					
					if ( !this.Parent_Turret.attacked && !Lang13.Bool( this.Parent_Turret.emagged ) ) {
						this.Parent_Turret.attacked = true;
						Task13.Schedule( 0, (Task13.Closure)(() => {
							Task13.Sleep( 30 );
							this.Parent_Turret.attacked = false;
							return;
						}));
					}
				}
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: portable_turret.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			dynamic _default = null;

			_default = base.attack_hand( (object)(a), b, c );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}
			return this.Parent_Turret.attack_hand( a );
		}

		// Function from file: portable_turret.dm
		public override dynamic attack_ai( dynamic user = null ) {
			dynamic _default = null;

			_default = base.attack_ai( (object)(user) );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}
			return this.Parent_Turret.attack_ai( user );
		}

	}

}
// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Twohanded_Singularityhammer : Obj_Item_Weapon_Twohanded {

		public int charged = 5;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 64;
			this.slot_flags = 1024;
			this.force = 5;
			this.force_unwielded = 5;
			this.force_wielded = 20;
			this.throwforce = 15;
			this.throw_range = 1;
			this.w_class = 5;
			this.origin_tech = "combat=5;bluespace=4";
			this.icon_state = "mjollnir0";
		}

		// Function from file: singularityhammer.dm
		public Obj_Item_Weapon_Twohanded_Singularityhammer ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.SSobj.processing.Or( this );
			return;
		}

		// Function from file: singularityhammer.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic Z = null;
			dynamic target2 = null;

			
			if ( !( proximity_flag == true ) ) {
				return false;
			}

			if ( this.wielded ) {
				
				if ( this.charged == 5 ) {
					this.charged = 0;

					if ( target is Mob_Living ) {
						Z = target;
						((Mob_Living)Z).take_organ_damage( 20, 0 );
					}
					GlobalFuncs.playsound( user, "sound/weapons/marauder.ogg", 50, 1 );
					target2 = GlobalFuncs.get_turf( target );
					this.vortex( target2, user );
				}
			}
			return false;
		}

		// Function from file: singularityhammer.dm
		public void vortex( dynamic pull = null, dynamic wielder = null ) {
			Ent_Static X = null;
			Ent_Static H = null;
			dynamic M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( pull, 5 ), typeof(Ent_Static) )) {
				X = _a;
				

				if ( X is Ent_Dynamic ) {
					
					if ( X == wielder ) {
						continue;
					}

					if ( X != null && !Lang13.Bool( ((dynamic)X).anchored ) && !( X is Mob_Living_Carbon_Human ) ) {
						Map13.StepTowardsSimple( (Ent_Dynamic)(X), pull );
						Map13.StepTowardsSimple( (Ent_Dynamic)(X), pull );
						Map13.StepTowardsSimple( (Ent_Dynamic)(X), pull );
					} else if ( X is Mob_Living_Carbon_Human ) {
						H = X;

						if ( ((dynamic)H).shoes is Obj_Item_Clothing_Shoes_Magboots ) {
							M = ((dynamic)H).shoes;

							if ( Lang13.Bool( M.magpulse ) ) {
								continue;
							}
						}
						((dynamic)H).apply_effect( 1, "weaken", 0 );
						Map13.StepTowardsSimple( (Ent_Dynamic)(H), pull );
						Map13.StepTowardsSimple( (Ent_Dynamic)(H), pull );
						Map13.StepTowardsSimple( (Ent_Dynamic)(H), pull );
					}
				}
			}
			return;
		}

		// Function from file: singularityhammer.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.icon_state = "mjollnir" + this.wielded;
			return false;
		}

		// Function from file: singularityhammer.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( this.charged < 5 ) {
				this.charged++;
			}
			return null;
		}

		// Function from file: singularityhammer.dm
		public override dynamic Destroy(  ) {
			GlobalVars.SSobj.processing.Remove( this );
			return base.Destroy();
		}

	}

}
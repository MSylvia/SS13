// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_Balloon : Obj_Item_Toy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "balloon-empty";
			this.icon = "icons/obj/toy.dmi";
			this.icon_state = "waterballoon-e";
		}

		// Function from file: toys.dm
		public Obj_Item_Toy_Balloon ( dynamic loc = null ) : base( (object)(loc) ) {
			this.create_reagents( 10 );
			return;
		}

		// Function from file: toys.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( ( this.reagents.total_volume ??0) >= 1 ) {
				this.icon_state = "waterballoon";
				this.item_state = "balloon";
			} else {
				this.icon_state = "waterballoon-e";
				this.item_state = "balloon-empty";
			}
			return false;
		}

		// Function from file: toys.dm
		public override bool throw_impact( dynamic target = null, Mob_Living_Carbon thrower = null ) {
			Ent_Static A = null;

			
			if ( !base.throw_impact( (object)(target), thrower ) ) {
				
				if ( ( this.reagents.total_volume ??0) >= 1 ) {
					this.visible_message( "<span class='danger'>" + this + " bursts!</span>", "<span class='italics'>You hear a pop and a splash.</span>" );
					this.reagents.reaction( GlobalFuncs.get_turf( target ) );

					foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( target ), typeof(Ent_Static) )) {
						A = _a;
						
						this.reagents.reaction( A );
					}
					this.icon_state = "burst";
					GlobalFuncs.qdel( this );
				}
			}
			return false;
		}

		// Function from file: toys.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Weapon_ReagentContainers_Glass ) {
				
				if ( Lang13.Bool( A.reagents ) ) {
					
					if ( ( A.reagents.total_volume ??0) <= 0 ) {
						user.WriteMsg( "<span class='warning'>" + A + " is empty.</span>" );
					} else if ( ( this.reagents.total_volume ??0) >= 10 ) {
						user.WriteMsg( "<span class='warning'>" + this + " is full.</span>" );
					} else {
						this.desc = "A translucent balloon with some form of liquid sloshing around in it.";
						user.WriteMsg( "<span class='notice'>You fill the balloon with the contents of " + A + ".</span>" );
						((Reagents)A.reagents).trans_to( this, 10 );
						this.update_icon();
					}
				}
			}
			return null;
		}

		// Function from file: toys.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic RD = null;

			
			if ( !( proximity_flag == true ) ) {
				return false;
			}

			if ( target is Obj_Structure_ReagentDispensers ) {
				RD = target;

				if ( ( RD.reagents.total_volume ??0) <= 0 ) {
					user.WriteMsg( "<span class='warning'>" + RD + " is empty.</span>" );
				} else if ( ( this.reagents.total_volume ??0) >= 10 ) {
					user.WriteMsg( "<span class='warning'>" + this + " is full.</span>" );
				} else {
					((Reagents)target.reagents).trans_to( this, 10 );
					user.WriteMsg( "<span class='notice'>You fill the balloon with the contents of " + target + ".</span>" );
					this.desc = "A translucent balloon with some form of liquid sloshing around in it.";
					this.update_icon();
				}
			}
			return false;
		}

		// Function from file: toys.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			return false;
		}

	}

}
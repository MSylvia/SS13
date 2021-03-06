// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Spider : Obj_Effect {

		public double health = 15;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/effects/effects.dmi";
		}

		public Obj_Effect_Spider ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: spiders.dm
		public override dynamic temperature_expose( GasMixture air = null, dynamic exposed_temperature = null, int? exposed_volume = null ) {
			
			if ( Convert.ToDouble( exposed_temperature ) > 300 ) {
				this.health -= 5;
				this.healthcheck();
			}
			return null;
		}

		// Function from file: spiders.dm
		public virtual void healthcheck(  ) {
			
			if ( this.health <= 0 ) {
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: spiders.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			base.bullet_act( (object)(P), (object)(def_zone) );
			this.health -= Convert.ToDouble( P.damage );
			this.healthcheck();
			return null;
		}

		// Function from file: spiders.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic damage = null;
			dynamic WT = null;

			
			if ( A.attack_verb.len != 0 ) {
				this.visible_message( new Txt( "<span class='danger'>" ).item( user ).str( " has " ).item( Rand13.PickFromTable( A.attack_verb ) ).str( " " ).the( this ).item().str( " with " ).the( A ).item().str( "!</span>" ).ToString() );
			} else {
				this.visible_message( new Txt( "<span class='danger'>" ).item( user ).str( " has attacked " ).the( this ).item().str( " with " ).the( A ).item().str( "!</span>" ).ToString() );
			}
			damage = A.force / 4;

			if ( A is Obj_Item_Weapon_Weldingtool ) {
				WT = A;

				if ( ((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 0, user ) ) {
					damage = 15;
					GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 100, 1 );
				}
			}
			this.health -= Convert.ToDouble( damage );
			this.healthcheck();
			return null;
		}

		// Function from file: spiders.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			
			switch ((int?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 5 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
			}
			return false;
		}

	}

}
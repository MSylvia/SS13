// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Spider_Stickyweb : Obj_Effect_Spider {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "stickyweb1";
		}

		// Function from file: effects.dm
		public Obj_Effect_Spider_Stickyweb ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Rand13.PercentChance( 50 ) ) {
				this.icon_state = "stickyweb2";
			}
			return;
		}

		// Function from file: effects.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;
			air_group = air_group ?? false;

			
			if ( air_group == true || height == 0 ) {
				return true;
			}

			if ( mover is Mob_Living_SimpleAnimal_Hostile_GiantSpider ) {
				return true;
			} else if ( mover is Mob_Living ) {
				
				if ( Rand13.PercentChance( 50 ) ) {
					GlobalFuncs.to_chat( mover, new Txt( "<span class='warning'>You get stuck in " ).the( this ).item().str( " for a moment.</span>" ).ToString() );
					return false;
				}
			} else if ( mover is Obj_Item_Projectile ) {
				return Rand13.PercentChance( 30 );
			}
			return true;
		}

	}

}
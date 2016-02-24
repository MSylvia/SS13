// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grown_Nettle_Basic : Obj_Item_Weapon_Grown_Nettle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_Nettleseed);
		}

		public Obj_Item_Weapon_Grown_Nettle_Basic ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: growninedible.dm
		public override bool add_juice(  ) {
			base.add_juice();
			this.reagents.add_reagent( "sacid", Num13.Round( ( this.potency ??0) / 2, 1 ) );
			this.force = Num13.Round( ( this.potency ??0) / 5 + 5, 1 );
			return false;
		}

	}

}
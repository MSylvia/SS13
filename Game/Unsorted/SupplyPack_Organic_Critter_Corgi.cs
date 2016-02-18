// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Organic_Critter_Corgi : SupplyPack_Organic_Critter {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Corgi Crate";
			this.cost = 50;
			this.contains = new ByTable(new object [] { typeof(Mob_Living_SimpleAnimal_Pet_Dog_Corgi), typeof(Obj_Item_Clothing_Tie_Petcollar) });
			this.crate_name = "corgi crate";
		}

		// Function from file: packs.dm
		public override dynamic generate( dynamic T = null ) {
			dynamic _default = null;

			dynamic D = null;

			_default = base.generate( (object)(T) );

			if ( Rand13.PercentChance( 50 ) ) {
				D = Lang13.FindIn( typeof(Mob_Living_SimpleAnimal_Pet_Dog_Corgi), _default );
				GlobalFuncs.qdel( D );
				new Mob_Living_SimpleAnimal_Pet_Dog_Corgi_Lisa( _default );
			}
			return _default;
		}

	}

}
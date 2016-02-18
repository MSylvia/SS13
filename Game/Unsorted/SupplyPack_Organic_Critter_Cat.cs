// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Organic_Critter_Cat : SupplyPack_Organic_Critter {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cat Crate";
			this.cost = 50;
			this.contains = new ByTable(new object [] { typeof(Mob_Living_SimpleAnimal_Pet_Cat), typeof(Obj_Item_Clothing_Tie_Petcollar), typeof(Obj_Item_Toy_Cattoy) });
			this.crate_name = "cat crate";
		}

		// Function from file: packs.dm
		public override dynamic generate( dynamic T = null ) {
			dynamic _default = null;

			dynamic C = null;

			_default = base.generate( (object)(T) );

			if ( Rand13.PercentChance( 50 ) ) {
				C = Lang13.FindIn( typeof(Mob_Living_SimpleAnimal_Pet_Cat), _default );
				GlobalFuncs.qdel( C );
				new Mob_Living_SimpleAnimal_Pet_Cat_Proc( _default );
			}
			return _default;
		}

	}

}
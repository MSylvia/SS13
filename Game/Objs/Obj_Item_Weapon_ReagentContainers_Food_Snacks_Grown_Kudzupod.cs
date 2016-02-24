// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Kudzupod : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown {

		public ByTable mutations = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_Kudzuseed);
			this.filling_color = "#6B8E23";
			this.icon_state = "kudzupod";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Kudzupod ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: grown.dm
		public override bool add_juice( dynamic loc = null, int? potency = null ) {
			
			if ( base.add_juice( (object)(loc), potency ) ) {
				this.reagents.add_reagent( "nutriment", Num13.Round( ( this.potency ??0) / 50, 1 ) + 1 );
				this.reagents.add_reagent( "charcoal", Num13.Round( ( this.potency ??0) / 25, 1 ) + 1 );
				this.bitesize = Num13.Round( ( this.reagents.total_volume ??0) / 2, 1 ) + 1;
			}
			return false;
		}

	}

}
// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Reishi : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_Reishimycelium);
			this.filling_color = "#FF4500";
			this.icon_state = "reishi";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Reishi ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: grown.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic _default = null;

			_default = base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Device_Analyzer_PlantAnalyzer ) {
				user.WriteMsg( "<span class='info'>- Anti-Toxin: <i>" + this.reagents.get_reagent_amount( "charcoal" ) + "%</i></span>" );
				user.WriteMsg( "<span class='info'>- Morphine: <i>" + this.reagents.get_reagent_amount( "morphine" ) + "%</i></span>" );
			}
			return _default;
		}

		// Function from file: grown.dm
		public override bool add_juice( dynamic loc = null, int? potency = null ) {
			base.add_juice( (object)(loc), potency );
			this.reagents.add_reagent( "nutriment", 1 );
			this.reagents.add_reagent( "charcoal", Num13.Round( ( this.potency ??0) / 3, 1 ) + 3 );
			this.reagents.add_reagent( "morphine", Num13.Round( ( this.potency ??0) / 3, 1 ) + 3 );
			this.bitesize = Num13.Round( ( this.reagents.total_volume ??0) / 2, 1 ) + 1;
			return false;
		}

	}

}
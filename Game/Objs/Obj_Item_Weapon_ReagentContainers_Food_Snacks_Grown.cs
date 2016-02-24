// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		public Type seed = null;
		public string plantname = "";
		public dynamic product = null;
		public int lifespan = 0;
		public int endurance = 0;
		public int maturation = 0;
		public bool production = false;
		public int yield = 0;
		public int plant_type = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.potency = -1;
			this.dried_type = -1;
			this.icon = "icons/obj/hydroponics/harvest.dmi";
		}

		// Function from file: grown.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			new_potency = new_potency ?? 50;

			dynamic S = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.potency = new_potency;
			this.pixel_x = Rand13.Int( -5, 5 );
			this.pixel_y = Rand13.Int( -5, 5 );

			if ( this.dried_type == -1 ) {
				this.dried_type = this.type;
			}

			if ( this.seed != null && this.lifespan == 0 ) {
				S = Lang13.Call( this.seed, this );
				this.lifespan = Convert.ToInt32( S.lifespan );
				this.endurance = Convert.ToInt32( S.endurance );
				this.maturation = Convert.ToInt32( S.maturation );
				this.production = Lang13.Bool( S.production );
				this.yield = Convert.ToInt32( S.yield );
				GlobalFuncs.qdel( S );
			}
			this.add_juice();
			this.transform *= GlobalFuncs.TransformUsingVariable( this.potency, 100, 0.5 );
			return;
		}

		// Function from file: grown.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			string msg = null;

			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Device_Analyzer_PlantAnalyzer ) {
				msg = new Txt( "<span class='info'>*---------*\n This is " ).a( this ).str( "<span class='name'>" ).item().str( "</span>\n" ).ToString();

				switch ((int)( this.plant_type )) {
					case 0:
						msg += "- Plant type: <i>Normal plant</i>\n";
						break;
					case 1:
						msg += "- Plant type: <i>Weed</i>.  Can grow in nutrient-poor soil.\n";
						break;
					case 2:
						msg += "- Plant type: <i>Mushroom</i>.  Can grow in dry soil.\n";
						break;
				}
				msg += "- Potency: <i>" + this.potency + "</i>\n";
				msg += "- Yield: <i>" + this.yield + "</i>\n";
				msg += "- Maturation speed: <i>" + this.maturation + "</i>\n";
				msg += "- Production speed: <i>" + this.production + "</i>\n";
				msg += "- Endurance: <i>" + this.endurance + "</i>\n";
				msg += "- Nutritional value: <i>" + this.reagents.get_reagent_amount( "nutriment" ) + "</i>\n";
				msg += "- Other substances: <i>" + ( ( this.reagents.total_volume ??0) - ( this.reagents.get_reagent_amount( "nutriment" ) ?1:0) ) + "</i>\n";
				msg += "*---------*</span>";
				Task13.User.WriteMsg( msg );
				return null;
			}
			return null;
		}

		// Function from file: grown.dm
		public virtual bool add_juice( dynamic loc = null, int? potency = null ) {
			
			if ( this.reagents != null ) {
				return true;
			}
			return false;
		}

	}

}
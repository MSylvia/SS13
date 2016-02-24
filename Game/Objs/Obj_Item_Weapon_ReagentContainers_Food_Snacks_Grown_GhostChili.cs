// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_GhostChili : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown {

		public Ent_Static held_mob = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_Chilighost);
			this.filling_color = "#F8F8FF";
			this.icon_state = "ghostchilipepper";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_GhostChili ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: grown.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( this.held_mob != null && this.loc == this.held_mob ) {
				
				if ( ((dynamic)this.held_mob).l_hand == this || ((dynamic)this.held_mob).r_hand == this ) {
					
					if ( GlobalFuncs.hasvar( this.held_mob, "gloves" ) && Lang13.Bool( ((dynamic)this.held_mob).gloves ) ) {
						return null;
					}
					((dynamic)this.held_mob).bodytemperature += 22.5;

					if ( Rand13.PercentChance( 10 ) ) {
						((dynamic)this.held_mob).WriteMsg( "<span class='warning'>Your hand holding " + this + " burns!</span>" );
					}
				}
			} else {
				this.held_mob = null;
				base.process( (object)(seconds) );
			}
			return null;
		}

		// Function from file: grown.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			base.attack_hand( (object)(a), b, c );

			if ( this.loc is Mob ) {
				this.held_mob = this.loc;
				GlobalVars.SSobj.processing.Or( this );
			}
			return null;
		}

		// Function from file: grown.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic _default = null;

			_default = base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Device_Analyzer_PlantAnalyzer ) {
				user.WriteMsg( "<span class='info'>- Capsaicin: <i>" + this.reagents.get_reagent_amount( "capsaicin" ) + "%</i></span>" );
			}
			return _default;
		}

		// Function from file: grown.dm
		public override bool add_juice( dynamic loc = null, int? potency = null ) {
			base.add_juice( (object)(loc), potency );
			this.reagents.add_reagent( "nutriment", Num13.Round( ( this.potency ??0) / 25, 1 ) + 1 );
			this.reagents.add_reagent( "capsaicin", Num13.Round( ( this.potency ??0) / 2, 1 ) + 8 );
			this.reagents.add_reagent( "condensedcapsaicin", Num13.Round( ( this.potency ??0) / 4, 1 ) + 4 );
			this.bitesize = Num13.Round( ( this.reagents.total_volume ??0) / 4, 1 ) + 1;
			return false;
		}

	}

}
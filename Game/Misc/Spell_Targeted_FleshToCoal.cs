// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Spell_Targeted_FleshToCoal : Spell_Targeted {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Flesh to Coal";
			this.desc = "This spell turns a single person into a coal golem slaved to the caster.";
			this.school = "transmutation";
			this.charge_max = 600;
			this.spell_flags = 130;
			this.range = 3;
			this.invocation = "NAUGHTY";
			this.invocation_type = "shout";
			this.amt_stunned = 5;
			this.cooldown_min = 200;
			this.hud_state = "wiz_statue";
		}

		// Function from file: flesh_to_coal.dm
		public override bool cast( ByTable targets = null, Mob user = null ) {
			Mob_Living_Carbon_Human H = null;
			Objective_Protect new_objective = null;

			base.cast( targets, user );

			foreach (dynamic _a in Lang13.Enumerate( targets, typeof(Mob_Living_Carbon_Human) )) {
				H = _a;
				
				H.drop_all();
				H.dna.mutantrace = "coalgolem";
				H.real_name = "Coal Golem (" + Rand13.Int( 1, 1000 ) + ")";
				H.equip_to_slot_or_del( new Obj_Item_Clothing_Under_Golem_Coal( H ), 14 );
				H.equip_to_slot_or_del( new Obj_Item_Clothing_Suit_Golem_Coal( H ), 13 );
				H.equip_to_slot_or_del( new Obj_Item_Clothing_Shoes_Golem_Coal( H ), 12 );
				H.equip_to_slot_or_del( new Obj_Item_Clothing_Mask_Gas_Golem_Coal( H ), 2 );
				H.equip_to_slot_or_del( new Obj_Item_Clothing_Gloves_Golem_Coal( H ), 10 );
				new_objective = new Objective_Protect();
				new_objective.owner = H.mind;
				new_objective.target = user.mind;
				new_objective.explanation_text = "Protect " + user.real_name + ", the wizard.";
				H.mind.objectives.Add( new_objective );
				GlobalVars.ticker.mode.traitors.Add( H.mind );
				H.mind.special_role = "apprentice";
				GlobalFuncs.to_chat( H, "You are a coal golem. You move slowly, but are highly resistant to heat and cold as well as blunt trauma. You are unable to wear clothes, but can still use most tools. Serve " + user + ", and assist them in completing their goals at any cost." );

				if ( GlobalVars.ticker.mode.name == "sandbox" ) {
					H.CanBuild();
					GlobalFuncs.to_chat( H, "Sandbox tab enabled." );
				}
			}
			return false;
		}

	}

}
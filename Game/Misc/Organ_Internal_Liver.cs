// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Organ_Internal_Liver : Organ_Internal {

		public int process_accuracy = 10;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "liver";
			this.removed_type = typeof(Obj_Item_Organ_Liver);
		}

		public Organ_Internal_Liver ( Mob_Living_Carbon_Human H = null ) : base( H ) {
			
		}

		// Function from file: organ_internal.dm
		public override bool process(  ) {
			dynamic O = null;
			Reagent R = null;
			dynamic toxin = null;

			base.process();

			if ( this.germ_level > 100 ) {
				
				if ( Rand13.PercentChance( 1 ) ) {
					GlobalFuncs.to_chat( this.owner, "<span class='warning'>Your skin itches.</span>" );
				}
			}

			if ( this.germ_level > 500 ) {
				
				if ( Rand13.PercentChance( 1 ) ) {
					Task13.Schedule( 0, (Task13.Closure)(() => {
						this.owner.vomit();
						return;
					}));
				}
			}

			if ( this.owner.life_tick % this.process_accuracy == 0 ) {
				
				if ( this.damage < 0 ) {
					this.damage = 0;
				}

				if ( Convert.ToDouble( this.owner.getToxLoss() ) >= 60 && !((Reagents)this.owner.reagents).has_reagent( "anti_toxin" ) ) {
					
					if ( this.damage < this.min_broken_damage ) {
						this.damage += this.process_accuracy * 0.2;
					} else {
						O = Rand13.PickFromTable( this.owner.internal_organs );

						if ( Lang13.Bool( O ) ) {
							O.damage += this.process_accuracy * 0.2;
						}
					}
				}

				if ( this.damage != 0 && this.damage < this.min_bruised_damage && ((Reagents)this.owner.reagents).has_reagent( "anti_toxin" ) ) {
					this.damage -= this.process_accuracy * 0.2;
				}

				if ( this.damage >= this.min_bruised_damage ) {
					
					foreach (dynamic _a in Lang13.Enumerate( this.owner.reagents.reagent_list, typeof(Reagent) )) {
						R = _a;
						

						if ( R is Reagent_Ethanol ) {
							this.owner.adjustToxLoss( this.process_accuracy * 0.1 );
						}
					}

					foreach (dynamic _b in Lang13.Enumerate( new ByTable(new object [] { "toxin", "plasma", "sacid", "pacid", "cyanide", "lexorin", "amatoxin", "chloralhydrate", "carpotoxin", "zombiepowder", "mindbreaker" }) )) {
						toxin = _b;
						

						if ( ((Reagents)this.owner.reagents).has_reagent( toxin ) ) {
							this.owner.adjustToxLoss( this.process_accuracy * 0.3 );
						}
					}
				}
			}
			return false;
		}

		// Function from file: organ_internal.dm
		public override dynamic Copy(  ) {
			dynamic I = null;

			I = base.Copy();
			I.process_accuracy = this.process_accuracy;
			return I;
		}

	}

}
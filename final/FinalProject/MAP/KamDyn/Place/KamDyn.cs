namespace FinalProjectGame.MAP.KamDyn.Place
{
    sealed class KamDyn : BasciMAP
    {
        protected override void SetNPC()
        {
            NPCs.Add(new WeirdGuy());
            NPCs.Add(new KamDynSeller());
        }
        protected override void SetPlace()
        {
            places.Add(new Paxtun.Place.Paxtun());
        }
        protected override void SetWeaponsMerchant()
        {
            NPCWeaponsMerchant = new KamDynSeller();
        }
        protected override void SetMonsters()
        {
            monsters.Add(new Boli());
        }

        protected override void TalkToVillagers()
        {
            int randm = new Random().Next(10);

            if(randm == 1 && (NPCs[0] as WeirdGuy) != null)
            {
                if(!GameSystem.IsWeirdGuyEventEnd && (NPCs[0] as WeirdGuy).Event())
                {
                    GameSystem.IsWeirdGuyEventEnd = (NPCs[0] as WeirdGuy).Talk();
                }
            }
            else
            {
                GameSystem.RandomConverSation();
            }
        }
    }
}
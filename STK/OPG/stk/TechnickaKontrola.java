package OPG.stk;

public class TechnickaKontrola {
    public static void main(String[] args) {
        MajitelAuta[] majitelia = {
            new MajitelAuta("John Doe", "New York", "ABC123"),
            new MajitelAuta("Jane Smith", "Los Angeles", "XYZ456"),
            new MajitelAuta("Michael Johnson", "Chicago", "DEF789"),
            new MajitelAuta("Emily Williams", "Houston", "GHI012"),
            new MajitelAuta("William Brown", "Phoenix", "JKL345"),
            new MajitelAuta("Emma Jones", "Philadelphia", "MNO678"),
            new MajitelAuta("James Davis", "San Antonio", "PQR901"),
            new MajitelAuta("Olivia Miller", "San Diego", "STU234")
        };
        
        Auto[] auta_zakladna_kontrola = {
            new BenzinoveAuto("12345678", "Ford Mustang", "červená"),
            new BenzinoveAuto("23456789", "Chevrolet Camaro", "modrá"),
            new ElektroAuto("34567890", "Tesla Model S", "biela"),
            new ElektroAuto("45678901", "Nissan Leaf", "strieborná"),
            new HybridneAuto("56789012", "Toyota Prius", "čierna"),
            new HybridneAuto("67890123", "Honda Insight", "zelená"),
            new PlynoveAuto("78901234", "Fiat Panda", "červená"),
            new PlynoveAuto("89012345", "Volkswagen Polo", "modrá")
        };
        
        BenzinovyPohon[] benzinoveAuta = {
                (BenzinovyPohon) auta_zakladna_kontrola[0],
                (BenzinovyPohon) auta_zakladna_kontrola[1]
        };

        ElektrickyPohon[] elektrickeAuta = {
                (ElektrickyPohon) auta_zakladna_kontrola[2],
                (ElektrickyPohon) auta_zakladna_kontrola[3]
        };

        HybridnyPohon[] hybridneAuta = {
                (HybridnyPohon) auta_zakladna_kontrola[4],
                (HybridnyPohon) auta_zakladna_kontrola[5]
        };

        PlynovyPohon[] plynoveAuta = {
                (PlynovyPohon) auta_zakladna_kontrola[6],
                (PlynovyPohon) auta_zakladna_kontrola[7]
        };

        System.out.println("-".repeat(50));
        System.out.println("Technicka Kontrola - Babjarčík Dávid III.SB 2.Skupina");
        System.out.println("Výpis:");
        System.out.println("-".repeat(50));

        diagnostikaZakladnychFunkciiAuta(auta_zakladna_kontrola, majitelia);

        diagnostikaSpecialnychFunkciiAuta(benzinoveAuta, elektrickeAuta, hybridneAuta, plynoveAuta);
    }

    private static void diagnostikaZakladnychFunkciiAuta(Auto[] auta, MajitelAuta[] majitelia) {
        for (int i = 0; i < auta.length; i++) {
            MajitelAuta majitel = majitelia[i];
            Auto autoObj = auta[i];

            System.out.println(majitel.getMeno() + " " + majitel.getMesto() + " " + majitel.getCisloOp());
            System.out.println(autoObj.getVinCislo());
            System.out.println(autoObj.getZnacka());
            System.out.println(autoObj.getFarba());
            autoObj.diagnostikaTlakuBrzdovejKvapaliny();
            autoObj.diagnostikaTlakuPneumatiky();
            autoObj.diagnostikaBezpecnostnehoSystemu();
            System.out.println("-".repeat(30));
        }
    }

    private static void diagnostikaSpecialnychFunkciiAuta(BenzinovyPohon[] benzinoveAuta,
                                                          ElektrickyPohon[] elektrickeAuta,
                                                          HybridnyPohon[] hybridneAuta,
                                                          PlynovyPohon[] plynoveAuta) {
        diagnostikaFunkcii(benzinoveAuta);
        diagnostikaFunkcii(elektrickeAuta);
        diagnostikaFunkcii(hybridneAuta);
        diagnostikaFunkcii(plynoveAuta);
    }

    private static void diagnostikaFunkcii(BenzinovyPohon[] auta) {
        for (BenzinovyPohon auto : auta) {
            auto.meranieTeplotyMotora();
            auto.meranieTlakuOleja();
            auto.meranieTlakuPaliva();
            System.out.println(".".repeat(50));
        }
    }

    private static void diagnostikaFunkcii(ElektrickyPohon[] auta) {
        for (ElektrickyPohon auto : auta) {
            auto.meranieNapatiaAkumulatora();
            System.out.println(".".repeat(50));
        }
    }

    private static void diagnostikaFunkcii(HybridnyPohon[] auta) {
        for (HybridnyPohon auto : auta) {
            auto.meranieNapatiaAkumulatora();
            auto.meranieTeplotyAkumulatorov();
            auto.meranieTlakuOleja();
            auto.meranieTlakuPaliva();
            System.out.println(".".repeat(50));
        }
    }

    private static void diagnostikaFunkcii(PlynovyPohon[] auta) {
        for (PlynovyPohon auto : auta) {
            auto.meranieTlakuPlynuVZasobniku();
            System.out.println(".".repeat(50));
        }
    }
}

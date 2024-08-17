namespace LogicaDePredicados
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Definición de algunas enfermedades
            Enfermedad gripe = new Enfermedad("Gripe");
            Enfermedad alergia = new Enfermedad("Alergia");
            Enfermedad neumonia = new Enfermedad("Neumonía");

            // Definición de algunos síntomas
            Sintoma fiebre = new Sintoma("Fiebre");
            Sintoma tos = new Sintoma("Tos");
            Sintoma estornudos = new Sintoma("Estornudos");

            // Relacionar enfermedades con síntomas
            RelacionDiagnostico diagnosticos = new RelacionDiagnostico();

            diagnosticos.AgregarSintoma(gripe, fiebre);
            diagnosticos.AgregarSintoma(gripe, tos);
            diagnosticos.AgregarSintoma(alergia, estornudos);
            diagnosticos.AgregarSintoma(neumonia, fiebre);
            diagnosticos.AgregarSintoma(neumonia, tos);

            // Verificar si una enfermedad tiene un síntoma
            Console.WriteLine($"¿La gripe tiene fiebre? {diagnosticos.TieneSintoma(gripe, fiebre)}");
            Console.WriteLine($"¿La alergia tiene tos? {diagnosticos.TieneSintoma(alergia, tos)}");
            Console.WriteLine($"¿La neumonía tiene tos? {diagnosticos.TieneSintoma(neumonia, tos)}");
            Console.WriteLine($"¿La gripe tiene estornudos? {diagnosticos.TieneSintoma(gripe, estornudos)}");
        }
    }

    // Clase que representa una enfermedad
    class Enfermedad
    {
        public string Nombre { get; }

        public Enfermedad(string nombre)
        {
            Nombre = nombre;
        }
    }

    // Clase que representa un síntoma
    class Sintoma
    {
        public string Nombre { get; }

        public Sintoma(string nombre)
        {
            Nombre = nombre;
        }
    }

    // Clase que gestiona la relación entre enfermedades y síntomas
    class RelacionDiagnostico
    {
        private List<Tuple<Enfermedad, Sintoma>> relacionesDiagnostico;

        public RelacionDiagnostico()
        {
            relacionesDiagnostico = new List<Tuple<Enfermedad, Sintoma>>();
        }

        public void AgregarSintoma(Enfermedad enfermedad, Sintoma sintoma)
        {
            relacionesDiagnostico.Add(new Tuple<Enfermedad, Sintoma>(enfermedad, sintoma));
        }

        public bool TieneSintoma(Enfermedad enfermedad, Sintoma sintoma)
        {
            return relacionesDiagnostico.Contains(new Tuple<Enfermedad, Sintoma>(enfermedad, sintoma));
        }
    }
}

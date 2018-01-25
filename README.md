# IoC-UnityDemo
Ejemplo para training como aplicar el concepto de Inyección Dependencias mediante IoC con Unity

### Nota sobre UnityDemo

1) El objetivo de este código es meramente informativo y con fines de formación donde mostramos como usar Unity de diferentes formas para inyectar dependencias sin resolver un "grafo de depencias"

2) Cualquier IoC está desaconsejado en diseños sencillos en los que la inyección de dependencias pueda realizarse de forma “manual”, asi: IGame game = new TrivialPursuit(); 
    
3) Unity o cualquier otro IoC se recomienda cuando resuelve todas las dependencias “encadenadas” de una clase de forma automática, en escenarios más simples o con poca complejidad no se recomienda a no ser que a futuro sea necesario utilizarlo.

### Información sobre Unity
Toda la documentación sobre Unity y Roadmap de versiones estan actualizadas aqui:
https://github.com/unitycontainer/unity

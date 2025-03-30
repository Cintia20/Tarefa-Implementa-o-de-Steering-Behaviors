1. Explicação dos Steering Behaviors implementados
Seek: O objetivo do comportamento Seek é mover um agente em direção a um ponto-alvo. A direção do movimento é calculada com base na posição atual do agente e na posição do destino, criando uma trajetória reta em direção ao alvo.
Arrival: O comportamento Arrival é semelhante ao Seek, mas com uma característica adicional: à medida que o agente se aproxima do alvo, ele diminui sua velocidade para evitar ultrapassar o ponto de chegada. Isso faz com que o agente desacelere conforme se aproxima do destino.
Wander: O comportamento Wander faz com que o agente se mova aleatoriamente dentro de uma área específica, simulando uma sensação de "vaguear". Isso pode ser utilizado para criar movimentos imprevisíveis ou naturais para personagens no jogo.
Flee: O comportamento Flee é o oposto do Seek. O agente se move para longe de um ponto de referência, geralmente utilizado para simular o movimento de fuga, como quando o agente está tentando escapar de um inimigo ou perigo.
Pursuit: O comportamento Pursuit envolve o movimento do agente em direção a um alvo que está se movendo. Ao contrário do Seek, onde o alvo é estacionário, o Pursuit calcula onde o alvo estará no futuro para que o agente possa interceptá-lo de forma eficaz.

2. Como utilizar o programa
Para utilizar o programa, siga os passos abaixo:
Configuração Inicial: Primeiro, certifique-se de que o ambiente de desenvolvimento está configurado corretamente o Unity.
Criação de Agentes: Instancie agentes no seu cenário, cada um com características como posição, velocidade e tamanho.
Aplicação de Steering Behaviors: Aplique os Steering Behaviors ao agente conforme o comportamento desejado. Por exemplo:
Para um agente buscar um alvo, aplique o comportamento Seek.
Para fazer um agente fugir de um ponto, aplique o comportamento Flee.
Configuração de Parâmetros: Ajuste os parâmetros dos comportamentos, como a distância de desaceleração para o Arrival ou a taxa de aleatoriedade para o Wander.
Execução: Execute o programa e observe o movimento dos agentes conforme eles seguem os comportamentos definidos.

3. Estrutura do código e principais arquivos na Unity
A estrutura do projeto na Unity pode ser organizada da seguinte maneira:

/Assets
    /Scripts
        - Seek.cs
        - Arrival.cs
        - Wander.cs
        - Flee.cs
        - Pursuit.cs
        - Agent.cs
    /Prefabs
        - AgentPrefab.prefab
    /Scenes
        - MainScene.unity
    /Materials
        - AgentMaterial.mat
Principais arquivos:
Seek.cs: Implementação do comportamento Seek. O script utiliza a posição do agente e do destino para calcular a direção.
Arrival.cs: Implementação do comportamento Arrival, com base na lógica do Seek, mas com desaceleração conforme o agente se aproxima do alvo.
Wander.cs: Implementação do comportamento Wander, usando uma abordagem de aleatoriedade para simular o movimento vagante.
Flee.cs: Implementação do comportamento Flee. O agente se move na direção oposta ao ponto de referência.
Pursuit.cs: Implementação do comportamento Pursuit, que calcula onde o alvo estará no futuro e ajusta a direção para interceptá-lo.
Agent.cs: Script que gerencia o agente na Unity, incluindo movimentação, detecção de comportamentos e aplicação de Steering Behaviors.
MainScene.unity: A cena principal da Unity onde os agentes e os comportamentos são testados.
AgentPrefab.prefab: Prefab do agente, que pode ser arrastado para a cena para testar os comportamentos.

4. Desafios encontrados e como foram resolvidos
Interação entre múltiplos comportamentos: Inicialmente, foi difícil fazer com que os agentes misturassem comportamentos de forma suave, como Seek e Flee ao mesmo tempo. A solução foi a criação de um sistema de prioridade onde certos comportamentos têm mais peso em determinadas situações, permitindo uma transição mais natural entre os comportamentos.
Físicas de colisão e interação com o ambiente: Durante a implementação, surgiram problemas de colisão entre os agentes e o ambiente. A resolução envolveu a implementação de um sistema de detecção de colisão simples, ajustando as trajetórias dos agentes para evitar obstáculos.

5. Lista de referências consultadas
"AI for Games" por Ian Millington: Um livro abrangente sobre IA aplicada a jogos, incluindo Steering Behaviors.
"Programming Game AI by Example" por Mat Buckland: Este livro foi útil para entender como implementar Steering Behaviors de forma prática.
Documentação oficial da Unity/Unreal Engine: Consultada para integrações e otimizações específicas da engine.
Artigos e tutoriais online sobre Steering Behaviors: Recursos como o site AI Game Programming Wisdom, que fornece exemplos e explicações detalhadas sobre comportamentos de agentes.

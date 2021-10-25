import logo from './logo.svg';
import './App.css';
import React from 'react';

function DataFormatada(props){
  return <h2>Horário Atual: {props.date.toLocaleTimeString()}</h2>
} 

//componente de classe
class Clock extends React.Component {
  constructor(props){
    super(props);
    this.state = {
      date : new Date(),
      pausado : false
    };
  };

  thick(){
    if (this.state.pausado === false) {
      this.setState({
        date : new Date()
      })
    }
  }

  //ciclo de vida de nascimento
  componentDidMount(){
    this.timerID = setInterval( () => {
      this.thick()
    }, 1000 )
  };

  componentWillUnmount(){
    clearInterval(this.timerID);
  };

  pausar(){
    if (this.state.pausado === true) {
      this.setState({
        pausado : false
      })
      this.timerID += 1;
      console.log('Relógio retomado!')
      console.log('Agora sou o relógio ' + this.timerID);
    } else{
    this.setState({
      pausado : true
    })
    console.log('Relógio ' + this.timerID + ' pausado');
  }
  }

  retomar(){
    this.setState({
      pausado : false
    })
    console.log('Relógio retomado!')
    console.log('Agora sou o relógio ' + this.timerID);
  }

  render(){
    return(
    <div>
      <h1>Relógio</h1>
      <DataFormatada date={this.state.date} />
      <button className="Pausar" onClick={() => this.pausar()}>PAUSAR</button>
    </div>
    )
  }
}

//componente funcional
function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Clock />
      </header>
    </div> 
  );
}

export default App;

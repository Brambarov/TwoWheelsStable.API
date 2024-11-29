import { ChangeEvent, SyntheticEvent, useState } from 'react';
import './App.css';
import CardList from './components/CardList/CardList';
import Search from './components/Search/Search';
import { MotorcycleSearch } from '../motorcycle';
import { searchMotorcycles } from './api';

function App() {    
  const [search, setSearch] = useState<string>("");
  const [searchResult, setSearchResult] = useState<MotorcycleSearch[]>([]);
  const [serverError, setServerError] = useState<string>("");

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
      setSearch(e.target.value);
      console.log(e);
  };

  const onClick = async (e: SyntheticEvent) => {
      const result = await searchMotorcycles(search);
      if(typeof result === "string")
      {
        setServerError(result);
      }
      else if (Array.isArray(result.data))
      {
        setSearchResult(result.data);
      }
      console.log(searchResult);
  };

  return (
    <div className="App">
      <Search onClick={onClick} search={search} handleChange={handleChange}/>
      {serverError && <h1>{serverError}</h1>}
      <CardList searchResults={searchResult}/>
    </div>
  );
}

export default App;

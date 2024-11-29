import { MotorcycleSearch } from '../../../motorcycle'
import Card from '../Card/Card'
import { v4 as uuidv4 } from 'uuid'

interface Props {
  searchResults: MotorcycleSearch[];
}

const CardList : React.FC<Props> = ({searchResults}: Props) : JSX.Element => {
  return <>{searchResults.length > 0 ? (
    searchResults.map((result) => {
      return <Card id={result.make} key={uuidv4()} searchResult={result}/>;
    })
  ) : (
    <h1>No result</h1>
  )
  }</>;
};

export default CardList
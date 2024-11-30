import { MotorcycleSearch } from '../../../motorcycle';
import './Card.css'

interface Props {
  id: string;
  searchResult: MotorcycleSearch;
}

const Card : React.FC<Props> = ({id, searchResult}: Props) : JSX.Element => {
  return (
    <div className='card'>
        <div className='details'>
          <img alt="Motorcycle picture"/>
            <h2>{searchResult.name}</h2>
            <p>{searchResult.make}</p>
            <p>{searchResult.model}</p>
            <p>{searchResult.year}</p>
            <p>{searchResult.mileage}</p>
            <p>{searchResult.owner}</p>
        </div>
        <p className='specs'>{searchResult.}</p>
    </div>
  )
}

export default Card;
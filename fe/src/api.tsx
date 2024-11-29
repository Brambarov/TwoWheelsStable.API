import axios from 'axios';
import { MotorcycleSearch } from "../motorcycle";

interface SearchResponse {
    data: MotorcycleSearch[];
}

export const searchMotorcycles = async (query: string) => {
    try {
        const data = await axios.get<SearchResponse>(
            `http://localhost:5000/api/motorcycles?make=${query}`
        );

        return data;
    } catch (error)
    {
      if (axios.isAxiosError(error)) {
        console.log("error message: ", error.message);
        return error.message;
      }
      else
      {
        console.log("Unexpected error: ", error);
        return "Unexpected error occurred!";
      }
    }
} 
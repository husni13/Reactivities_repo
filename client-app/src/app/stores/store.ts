import { createContext, useContext } from "react";
import AcivityStore from "./activityStore";

interface Store {
    activityStore: AcivityStore
}

export const store: Store = {
    activityStore: new AcivityStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}
import { createContext, useContext } from "react";
import AcivityStore from "./activityStore";
import CommonStore from "./commonStore";

interface Store {
    activityStore: AcivityStore;
    commonStore: CommonStore;
}

export const store: Store = {
    activityStore: new AcivityStore(),
    commonStore: new CommonStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}